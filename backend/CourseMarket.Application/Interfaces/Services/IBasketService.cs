using CourseMarket.Application.DTOs.Basket;
using CourseMarket.Application.Wrappers;
using CourseMarket.Domain.Entities;

namespace CourseMarket.Application.Interfaces.Services;

public interface IBasketService
{
    Task<ServiceResult<List<BasketItemDto>>> GetBasketItemsAsync();
    Task<ServiceResult> AddCourseAsync(Guid courseId);
    Task<ServiceResult> RemoveCourseAsync(Guid courseId);
}