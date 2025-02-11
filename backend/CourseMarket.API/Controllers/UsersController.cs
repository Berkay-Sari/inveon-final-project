﻿using CourseMarket.Application.DTOs.User;
using CourseMarket.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
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

    [HttpGet("courses")]
    [Authorize]
    public async Task<IActionResult> GetCourses()
    {
        return CreateActionResult(await userService.GetCoursesAsync());
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Profile()
    {
        return CreateActionResult(await userService.GetProfileInfo());
    }

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> UpdateProfile([FromBody] UpdateUserProfileRequest request)
    {
        return CreateActionResult(await userService.UpdateProfileInfo(request));
    }

    [HttpPut("change-password")]
    [Authorize]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
    {
        return CreateActionResult(await userService.ChangePassword(request));
    }

}