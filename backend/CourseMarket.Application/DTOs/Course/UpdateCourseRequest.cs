namespace CourseMarket.Application.DTOs.Course;

public record UpdateCourseRequest(
    string Name,
    string? Description,
    decimal Price,
    string Category
);
