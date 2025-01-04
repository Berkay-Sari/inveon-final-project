using CourseMarket.Application.DTOs;
using CourseMarket.Application.DTOs.Course;
using CourseMarket.Application.Wrappers;

namespace CourseMarket.Application.Interfaces.Services;

public interface ICourseService
{
    Task<ServiceResult<PaginatedResult<CourseDto>>> GetAllAsync(Pagination pagination);
    Task<ServiceResult<CourseDetailDto>> GetByIdAsync(Guid id);

    Task<ServiceResult<Guid>> CreateAsync(CreateCourseRequest request);
    Task<ServiceResult> UpdateAsync(Guid id, UpdateCourseRequest request);
    Task<ServiceResult> DeleteAsync(Guid id);

    Task<ServiceResult<PaginatedResult<CourseDto>>> GetByNameAsync(string name, Pagination pagination);
}