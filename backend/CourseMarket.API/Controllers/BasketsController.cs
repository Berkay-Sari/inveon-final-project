using CourseMarket.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseMarket.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BasketsController(IBasketService basketService) : CustomBaseController
{
    [HttpGet]
    public async Task<IActionResult> Read()
    {
        return CreateActionResult(await basketService.GetBasketItemsAsync());
    }
    
    [HttpPost("{courseId:guid}")]
    public async Task<IActionResult> AddItem(Guid courseId)
    {
        return CreateActionResult(await basketService.AddItemToBasketAsync(courseId));
    }

    [HttpDelete("{courseId:guid}")]
    public async Task<IActionResult> RemoveItem(Guid courseId)
    {
        return CreateActionResult(await basketService.RemoveItemFromBasketAsync(courseId));
    }
}