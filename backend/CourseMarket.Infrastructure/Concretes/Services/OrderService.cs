using System.Net;
using CourseMarket.Application.DTOs.Basket;
using CourseMarket.Application.DTOs.Order;
using CourseMarket.Application.Interfaces.Repositories.Order;
using CourseMarket.Application.Interfaces.Services;
using CourseMarket.Application.Interfaces.UnitOfWork;
using CourseMarket.Application.Wrappers;
using CourseMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseMarket.Infrastructure.Concretes.Services;

public class OrderService(
    IOrderReadRepository orderReadRepository,
    IOrderWriteRepository orderWriteRepository,
    IBasketService basketService,
    IUnitOfWork unitOfWork
    ) : IOrderService
{
    public async Task<ServiceResult> CreateOrderAsync(CreateOrderDto createOrderDto)
    {
        var orderCode = (new Random().NextDouble() * 10000).ToString();
        orderCode = orderCode.Substring(orderCode.IndexOf(".") + 1, orderCode.Length - orderCode.IndexOf(".") - 1);
        var order = new Order
        {
            Address = createOrderDto.Address,
            Id = basketService.GetUserActiveBasket.Id,
            OrderCode = orderCode
        };

        var result = await orderWriteRepository.AddAsync(order);
        if (result == false)
        {
            ServiceResult.Error("Order creation failed", HttpStatusCode.BadRequest);
        }
        await unitOfWork.SaveChangesAsync();
        return ServiceResult.SuccessAsNoContent();
    }

    public async Task<ServiceResult<OrderDto>> GetOrderByIdAsync(Guid id)
    {

        var data = orderReadRepository.Table
            .Include(o => o.Basket)
            .ThenInclude(b => b.Items);

        var order = await data.FirstOrDefaultAsync(o => o.Id == id);

        if (order is null)
        {
            return ServiceResult<OrderDto>.Error("Order not found",
                $"The order with id({id}) was not found", HttpStatusCode.NotFound);
        }

        var orderDto = new OrderDto
        (
            order.Id,
            order.Address,
            order.Basket.Items.Select(item => new BasketItemDto(
               item.CourseName, item.ImageUrl, item.Price, item.CourseId, item.Id)
            ).ToList(),
            order.OrderCode,
            order.CreatedDate
        );

        return ServiceResult<OrderDto>.SuccessAsOk(orderDto);
    }

    public async Task<ServiceResult<List<OrderDto>>> GetOrdersByUserIdAsync(Guid userId)
    {
        var data = orderReadRepository.Table
            .Include(o => o.Basket)
            .ThenInclude(b => b.Items);
        var orders = await data.Where(o => o.Basket.UserId == userId).ToListAsync();
        var orderDtos = orders.Select(order => new OrderDto
        (
            order.Id,
            order.Address,
            order.Basket.Items.Select(item => new BasketItemDto(
               item.CourseName, item.ImageUrl, item.Price, item.CourseId, item.Id)
            ).ToList(),
            order.OrderCode,
            order.CreatedDate
        )).ToList();

        return ServiceResult<List<OrderDto>>.SuccessAsOk(orderDtos);
    }
}