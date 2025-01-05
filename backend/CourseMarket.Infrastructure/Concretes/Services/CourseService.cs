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
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CourseMarket.Infrastructure.Concretes.Services;

public class CourseService(
    ICourseReadRepository courseReadRepository,
    ICourseWriteRepository courseWriteRepository,
    ICourseImageFileReadRepository courseImageFileReadRepository,
    UserManager<AppUser> userManager,
    IUnitOfWork unitOfWork,
    IStorageService storageService,
    ILogger<CourseService> logger
    ) : ICourseService
{
    public async Task<ServiceResult<PaginatedResult<CourseDto>>> GetAllAsync(Pagination pagination)
    {
        var query = courseReadRepository.GetAll();
        var paginatedResult = await GetPaginatedCoursesAsync(query, pagination);
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

        var courseImage = await courseImageFileReadRepository.GetByCourseIdAsync(id);
        var instructor = await userManager.FindByIdAsync(hasCourse.InstructorId.ToString());
        var instructorName = instructor?.FullName ?? "Unknown";

        var courseAsDto = new CourseDetailDto
        (
            hasCourse.Id,
            hasCourse.Name,
            hasCourse.Description,
            hasCourse.Price,
            hasCourse.Category,
            courseImage!.Path,
            instructorName
        );
        return ServiceResult<CourseDetailDto>.SuccessAsOk(courseAsDto);
    }

    public async Task<ServiceResult<Guid>> CreateAsync(CreateCourseRequest request)
    {
        var newCourse = request.Adapt<Course>();
        await UploadImageAsync(newCourse, request.Image);
        var result = await courseWriteRepository.AddAsync(newCourse);

        if (!result)
        {
            logger.LogError("Course creation failed: {Course}", newCourse);
            return ServiceResult<Guid>.Error("Course creation failed",
                "The course could not be created", HttpStatusCode.InternalServerError);
        }

        await unitOfWork.SaveChangesAsync();
        return ServiceResult<Guid>.SuccessAsCreated(newCourse.Id, $"/api/Courses/{newCourse.Id}");
    }

    public async Task<ServiceResult> UpdateAsync(Guid id, UpdateCourseRequest request)
    {
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

    public async Task<ServiceResult<PaginatedResult<CourseDto>>> GetByNameAsync(string name, Pagination pagination)
    {
        var query = courseReadRepository.GetAll()
            .Where(x => EF.Functions.Like(x.Name.ToLower(), $"%{name.ToLower()}%"));
        var paginatedResult = await GetPaginatedCoursesAsync(query, pagination);
        return ServiceResult<PaginatedResult<CourseDto>>.SuccessAsOk(paginatedResult);
    }

    private async Task<PaginatedResult<CourseDto>> GetPaginatedCoursesAsync(IQueryable<Course> query, Pagination pagination)
    {
        var totalCount = await query.CountAsync();
        var totalPages = (int)Math.Ceiling(totalCount / (double)pagination.Size);

        var coursesAsDto = await query
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
                return course with { ImageUrl = imagePath! };
            }).ToList();

        return new PaginatedResult<CourseDto>(coursesAsDtoWithImageUrl, pagination.Page, totalPages);
    }

}


