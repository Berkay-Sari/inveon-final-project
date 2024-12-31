using CourseMarket.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace CourseMarket.Application.DTOs.Course;

public record CreateCourseRequest(
    string Name,
    string? Description,
    decimal Price,
    string Category,
    Guid InstructorId,
    IFormFile Image
);
