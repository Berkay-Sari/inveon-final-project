using System.Net;
using CourseMarket.Application.DTOs.User;
using CourseMarket.Application.Interfaces.Services;
using CourseMarket.Application.Wrappers;
using CourseMarket.Domain.Entities;
using CourseMarket.Infrastructure.Context;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CourseMarket.Infrastructure.Concretes.Services;

public class UserService(
    UserManager<AppUser> userManager,
    IConfiguration configuration,
    IHttpContextAccessor httpContextAccessor,
    ILogger<UserService> logger
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

        logger.LogError("User creation failed: {Errors}", errorDetails.Detail);

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

        logger.LogError("Refresh token update failed: {Errors}", errorDetails.Detail);

        return ServiceResult.Error(errorDetails, HttpStatusCode.BadRequest);
    }

    public async Task<ServiceResult<List<Guid>>> GetCoursesAsync()
    {
        var userId = UserContext.GetUserId(httpContextAccessor);
        var user = await userManager.FindByIdAsync(userId.ToString());
        var courseIdList = user!.GetOwnedCourseIds();
        return ServiceResult<List<Guid>>.SuccessAsOk(courseIdList);
    }

    public async Task<ServiceResult<UserProfileResponse>> GetProfileInfo()
    {
        var userId = UserContext.GetUserId(httpContextAccessor);
        var user = await userManager.FindByIdAsync(userId.ToString());
        var userProfile = user.Adapt<UserProfileResponse>();
        return ServiceResult<UserProfileResponse>.SuccessAsOk(userProfile);
    }

    public async Task<ServiceResult> UpdateProfileInfo(UpdateUserProfileRequest request)
    {
        var userId = UserContext.GetUserId(httpContextAccessor);
        var user = await userManager.FindByIdAsync(userId.ToString());

        user!.Email = request.Email;
        user.PhoneNumber = request.PhoneNumber;

        var result = await userManager.UpdateAsync(user);
        if (result.Succeeded)
        {
            return ServiceResult.SuccessAsNoContent();
        }

        var errorDetailsForUpdate = new ProblemDetails
        {
            Title = "User update failed",
            Detail = string.Join(", ", result.Errors.Select(e => e.Description)),
            Status = (int)HttpStatusCode.BadRequest
        };
        logger.LogError("User update failed: {Errors}, User: {UserName}", errorDetailsForUpdate.Detail, user.UserName);

        return ServiceResult.Error(errorDetailsForUpdate, HttpStatusCode.BadRequest);
    }
}