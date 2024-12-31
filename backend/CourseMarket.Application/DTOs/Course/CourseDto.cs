namespace CourseMarket.Application.DTOs.Course;

public record CourseDto(
    Guid Id,
    string Name,
    string? Description,
    decimal Price,
    string ImageUrl
);
