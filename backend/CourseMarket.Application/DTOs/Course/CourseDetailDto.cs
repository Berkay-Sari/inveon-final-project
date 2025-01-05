namespace CourseMarket.Application.DTOs.Course;

public record CourseDetailDto(
    Guid Id,
    string Name,
    string? Description,
    decimal Price,
    string Category,
    string ImageUrl,
    string InstructorName
);
