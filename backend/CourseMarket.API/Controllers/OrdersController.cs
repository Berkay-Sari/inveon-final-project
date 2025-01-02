using CourseMarket.Application.DTOs.Order;
using CourseMarket.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseMarket.API.Controllers;


[Route("api/[controller]")]
[ApiController]
[Authorize]
public class OrdersController(IOrderService orderService) : CustomBaseController
{
    [HttpGet("order/{id:guid}")]
    public async Task<IActionResult> Read(Guid id)
    {
        return CreateActionResult(await orderService.GetOrderByIdAsync(id));
    }

    [HttpGet("user/{userId:guid}")]
    public async Task<IActionResult> ReadByUser(Guid userId)
    {
        return CreateActionResult(await orderService.GetOrdersByUserIdAsync(userId));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderDto createOrderDto)
    {
        return CreateActionResult(await orderService.CreateOrderAsync(createOrderDto));
    }
}

