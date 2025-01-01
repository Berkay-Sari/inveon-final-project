using System.Net;
using CourseMarket.Application.DTOs.Token;
using CourseMarket.Application.DTOs.User;
using CourseMarket.Application.Interfaces.Services;
using CourseMarket.Application.Wrappers;
using CourseMarket.Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CourseMarket.Infrastructure.Concretes.Services;

public class UserService(
    UserManager<AppUser> userManager,
    SignInManager<AppUser> signInManager,
    ITokenService tokenService,
    IConfiguration configuration
    ) : IUserService
{
    public async Task<ServiceResult<IdentityResult>> CreateAsync(CreateUserRequest userDto)
    {
        var user = userDto.Adapt<AppUser>();
        var result = await userManager.CreateAsync(user, userDto.Password);

        if (result.Succeeded)
        {
            return ServiceResult<IdentityResult>.SuccessAsCreated(result, $"/api/Users/{user.Id}");
        }

        var errorDetails = new ProblemDetails
        {
            Title = "User Creation Failed",
            Detail = string.Join(", ", result.Errors.Select(e => e.Description)),
            Status = (int)HttpStatusCode.BadRequest
        };

        return ServiceResult<IdentityResult>.Error(errorDetails, HttpStatusCode.BadRequest);
    }

    public async Task<ServiceResult> UpdateRefreshTokenAsync(string refreshToken, AppUser user)
    {
        var refreshTokenLifeTime = int.Parse(configuration["TokenOptions:RefreshTokenExpiration"]);

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddHours(refreshTokenLifeTime);

        var result = await userManager.UpdateAsync(user);

        if (result.Succeeded)
        {
            return ServiceResult.SuccessAsNoContent();
        }

        var errorDetails = new ProblemDetails
        {
            Title = "Refresh Token Update Failed",
            Detail = string.Join(", ", result.Errors.Select(e => e.Description)),
            Status = (int)HttpStatusCode.BadRequest
        };

        return ServiceResult.Error(errorDetails, HttpStatusCode.BadRequest);
    }
}
