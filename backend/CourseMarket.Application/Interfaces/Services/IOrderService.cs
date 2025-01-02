using CourseMarket.Application.DTOs.Order;
using CourseMarket.Application.Wrappers;
using CourseMarket.Domain.Entities;

namespace CourseMarket.Application.Interfaces.Services;

public interface IOrderService
{
    Task<ServiceResult> CreateOrderAsync(CreateOrderDto createOrderDto);

    Task<ServiceResult<OrderDto>> GetOrderByIdAsync(Guid id);

    Task<ServiceResult<List<OrderDto>>> GetOrdersByUserIdAsync(Guid userId);
}