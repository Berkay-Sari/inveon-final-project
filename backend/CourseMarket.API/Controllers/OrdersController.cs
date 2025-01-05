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
    [HttpPost]
    public async Task<IActionResult> Upsert([FromQuery] decimal totalAmount)
    {
        return CreateActionResult(await orderService.UpsertOrderAsync(totalAmount));
    }

    [HttpGet]
    public async Task<IActionResult> GetOrderHistory()
    {
        return CreateActionResult(await orderService.GetOrderHistoryAsync());
    }
}

