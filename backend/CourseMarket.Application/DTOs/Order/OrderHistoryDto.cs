namespace CourseMarket.Application.DTOs.Order;

public record OrderHistoryDto(string OrderCode, DateTime Date, List<OrderCourseDto> Courses);

public record OrderCourseDto(string Name, decimal Price);