using System.Net;
using CourseMarket.Application.DTOs;
using CourseMarket.Application.DTOs.Course;
using CourseMarket.Application.Interfaces.Repositories.Course;
using CourseMarket.Application.Interfaces.Repositories.CourseImageFile;
using CourseMarket.Application.Interfaces.Services;
using CourseMarket.Application.Interfaces.Storage;
using CourseMarket.Application.Interfaces.UnitOfWork;
using CourseMarket.Application.Wrappers;
using CourseMarket.Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CourseMarket.Infrastructure.Concretes.Services;

public class CourseService(
    ICourseReadRepository courseReadRepository,
    ICourseWriteRepository courseWriteRepository,
    ICourseImageFileReadRepository courseImageFileReadRepository,
    IUnitOfWork unitOfWork,
    IStorageService storageService
    ) : ICourseService
{
    public async Task<ServiceResult<PaginatedResult<CourseDto>>> GetAllAsync(Pagination pagination)
    {
        var totalCount = await courseReadRepository.GetAll().CountAsync();
        var totalPages = (int)Math.Ceiling(totalCount / (double)pagination.Size);

        var coursesAsDto = await courseReadRepository.GetAll()
            .Skip((pagination.Page - 1) * pagination.Size)
            .Take(pagination.Size)
            .Select(x => x.Adapt<CourseDto>())
            .ToListAsync();

        // Fetch all required course images in a single query
        var courseIds = coursesAsDto.Select(x => x.Id).ToList();
        var courseImages = await courseImageFileReadRepository.GetAll()
            .Where(image => courseIds.Contains(image.CourseId))
            .ToDictionaryAsync(image => image.CourseId, image => image.Path);

        var coursesAsDtoWithImageUrl = coursesAsDto
            .Select(course =>
            {
                var imagePath = courseImages.GetValueOrDefault(course.Id);
                var imageUrl = imagePath != null ? storageService.GetFile(imagePath) : null;
                return course with { ImageUrl = imageUrl! };
            }).ToList();

        var paginatedResult = new PaginatedResult<CourseDto>(coursesAsDtoWithImageUrl, pagination.Page, totalPages);
        return ServiceResult<PaginatedResult<CourseDto>>.SuccessAsOk(paginatedResult);
    }

    public async Task<ServiceResult<CourseDetailDto>> GetByIdAsync(Guid id)
    {
        var hasCourse = await courseReadRepository.GetByIdAsync(id);
        if (hasCourse is null)
        {
            return ServiceResult<CourseDetailDto>.Error("Course not found",
                $"The course with id({id}) was not found", HttpStatusCode.NotFound);
        }
        var courseAsDto = hasCourse.Adapt<CourseDetailDto>();
        return ServiceResult<CourseDetailDto>.SuccessAsOk(courseAsDto);
    }

    public async Task<ServiceResult<Guid>> CreateAsync(CreateCourseRequest request)
    {
        var hasCourse = await courseReadRepository.AnyAsync(x => x.Name == request.Name);
        if (hasCourse)
        {
            return ServiceResult<Guid>.Error("Course already exists.",
                $"The Course with name({request.Name}) already exists", HttpStatusCode.BadRequest);
        }
        var newCourse = request.Adapt<Course>();
        await UploadImageAsync(newCourse, request.Image);
        await courseWriteRepository.AddAsync(newCourse);
        await unitOfWork.SaveChangesAsync();
        return ServiceResult<Guid>.SuccessAsCreated(newCourse.Id, $"/api/courses/{newCourse.Id}");
    }

    public async Task<ServiceResult> UpdateAsync(Guid id, UpdateCourseRequest request)
    {
        var isCourseNameExist = await courseReadRepository.AnyAsync(x => x.Name == request.Name && x.Id != id);
        if (isCourseNameExist)
        {
            return ServiceResult.Error("Course already exists.",
                $"The Course with name({request.Name}) already exists", HttpStatusCode.BadRequest);
        }

        var hasCourse = await courseReadRepository.GetByIdAsync(id, true);
        if (hasCourse is null)
        {
            return ServiceResult.ErrorAsNotFound();
        }
        hasCourse = request.Adapt(hasCourse);
        courseWriteRepository.Update(hasCourse);
        await unitOfWork.SaveChangesAsync();
        return ServiceResult.SuccessAsNoContent();
    }

    public async Task<ServiceResult> DeleteAsync(Guid id)
    {
        var hasCourse = await courseReadRepository.GetByIdAsync(id, true);
        if (hasCourse is null)
        {
            return ServiceResult.ErrorAsNotFound();
        }
        courseWriteRepository.Delete(hasCourse);
        await unitOfWork.SaveChangesAsync();
        return ServiceResult.SuccessAsNoContent();
    }

    public async Task<ServiceResult> UploadImageAsync(Course course, IFormFile imageFile)
    {
        //TODO: Add FluentValidation for image
        // null, big size, not image, etc.

        var data = await storageService.UploadAsync(
            "resource/course-images", imageFile);

        course.Image = new CourseImageFile
        {
            FileName = data.fileName,
            Path = data.pathOrContainerName,
            Storage = storageService.StorageType,
            CourseId = course.Id
        };

        return ServiceResult.SuccessAsNoContent();
    }
}


