namespace CourseMarket.Application.DTOs.Basket;

public record BasketItemDto(
    string CourseName,
    string ImageUrl,
    decimal Price,
    Guid CourseId,
    Guid BasketItemId
    );
