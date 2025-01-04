using CourseMarket.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseMarket.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]

public class PaymentsController(IPaymentService paymentService) : CustomBaseController
{
    [HttpPost]
    public async Task<IActionResult> Pay([FromQuery] bool isSuccess)
    {
        return CreateActionResult(await paymentService.PayAsync(isSuccess));
    }
}