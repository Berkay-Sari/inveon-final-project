using CourseMarket.Application.DTOs.User;
using CourseMarket.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseMarket.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IAuthService authService) : CustomBaseController
{
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        return CreateActionResult(await authService.LoginAsync(loginRequest));
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshTokenLogin([FromBody] string refreshToken)
    {
        return CreateActionResult(await authService.RefreshTokenLoginAsync(refreshToken));
    }
}