using System.Net;
using CourseMarket.Application.DTOs.Course;
using CourseMarket.Application.Interfaces.Repositories.Course;
using CourseMarket.Application.Interfaces.Services;
using CourseMarket.Application.Interfaces.UnitOfWork;
using CourseMarket.Application.Wrappers;
using CourseMarket.Domain.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace CourseMarket.Infrastructure.Concretes.Services;

public class CourseService(
    ICourseReadRepository courseReadRepository,
    ICourseWriteRepository courseWriteRepository,
    IUnitOfWork unitOfWork
    ) : ICourseService
{
    public async Task<ServiceResult<List<CourseDto>>> GetAllAsync()
    {
        var courses = await courseReadRepository.GetAll().ToListAsync();
        var coursesAsDto = courses.Adapt<List<CourseDto>>();
        return ServiceResult<List<CourseDto>>.SuccessAsOk(coursesAsDto);
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
        await courseWriteRepository.AddAsync(newCourse);
        await unitOfWork.SaveChangesAsync();
        return ServiceResult<Guid>.SuccessAsCreated(newCourse.Id, $"/api/courses/{newCourse.Id}");
    }

    public async Task<ServiceResult> UpdateAsync(Guid id, UpdateCourseRequest request)
    {
        //TO-DO: add fluent validation for null field check, price greater than 0, etc.
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
}


