using CourseMarket.Application.DTOs.Basket;

namespace CourseMarket.Application.DTOs.Order;

public record OrderDto(
    Guid Id,
    string Address,
    List<BasketItemDto> BasketItems,
    string OrderCode,
    DateTime CreatedDate
    );