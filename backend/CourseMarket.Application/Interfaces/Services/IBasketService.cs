using CourseMarket.Application.DTOs.Basket;
using CourseMarket.Application.Wrappers;
using CourseMarket.Domain.Entities;

namespace CourseMarket.Application.Interfaces.Services;

public interface IBasketService
{
    Task<ServiceResult<List<BasketItemDto>>> GetBasketItemsAsync();
    Task<ServiceResult> AddItemToBasketAsync(Guid basketItemId);
    Task<ServiceResult> RemoveItemFromBasketAsync(Guid basketItemId);
    Basket? GetUserActiveBasket { get; }
}