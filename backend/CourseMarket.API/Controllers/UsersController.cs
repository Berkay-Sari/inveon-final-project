using CourseMarket.Application.DTOs.User;
using CourseMarket.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseMarket.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(IUserService userService) : CustomBaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
    {
        return CreateActionResult(await userService.CreateAsync(request));
    }

}