namespace CourseMarket.Application.DTOs.Basket;

public record BasketItemDto(
    Guid CourseId,
    string CourseName,
    decimal Price,
    string ImageUrl
    );
