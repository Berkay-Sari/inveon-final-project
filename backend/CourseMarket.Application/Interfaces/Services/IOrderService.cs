using CourseMarket.Application.DTOs.Order;
using CourseMarket.Application.Wrappers;
using CourseMarket.Domain.Entities;

namespace CourseMarket.Application.Interfaces.Services;

public interface IOrderService
{
    Task<ServiceResult> UpsertOrderAsync(decimal totalAmount);
    string CompleteOrder(Order order);
    Task<ServiceResult<List<OrderHistoryDto>>> GetOrderHistoryAsync();
}