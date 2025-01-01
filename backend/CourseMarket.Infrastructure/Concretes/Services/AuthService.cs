using System.Net;
using CourseMarket.Application.DTOs.Token;
using CourseMarket.Application.DTOs.User;
using CourseMarket.Application.Interfaces.Services;
using CourseMarket.Application.Wrappers;
using CourseMarket.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseMarket.Infrastructure.Concretes.Services;

public class AuthService(
    SignInManager<AppUser> signInManager,
    UserManager<AppUser> userManager,
    ITokenService tokenService,
    IUserService userService
) : IAuthService
{
    public async Task<ServiceResult<TokenDto>> LoginAsync(LoginRequest loginRequest)
    {
        var user = await userManager.FindByNameAsync(loginRequest.UserName);
        if (user == null || !(await signInManager.CheckPasswordSignInAsync(user, loginRequest.Password, false))
                .Succeeded)
        {
            return ServiceResult<TokenDto>.Error(new ProblemDetails
            {
                Title = "Login Failed",
                Detail = "Invalid username or password",
                Status = (int)HttpStatusCode.BadRequest
            }, HttpStatusCode.BadRequest);
        }

        var token = tokenService.CreateAccessToken(user);
        await userService.UpdateRefreshTokenAsync(token.RefreshToken, user);

        return ServiceResult<TokenDto>.SuccessAsCreated(token, " ");
    }

    public async Task<ServiceResult<TokenDto>> RefreshTokenLoginAsync(string refreshToken)
    {
        var user = await userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
        if (user == null)
        {
            return ServiceResult<TokenDto>.Error(new ProblemDetails
            {
                Title = "Login Failed",
                Detail = "Invalid refresh token",
                Status = (int)HttpStatusCode.BadRequest
            }, HttpStatusCode.BadRequest);
        }

        if (user.RefreshTokenExpiryTime < DateTime.UtcNow)
        {
            return ServiceResult<TokenDto>.Error(new ProblemDetails
            {
                Title = "Login Failed",
                Detail = "Refresh token expired",
                Status = (int)HttpStatusCode.BadRequest
            }, HttpStatusCode.BadRequest);
        }


        var token = tokenService.CreateAccessToken(user);
        await userService.UpdateRefreshTokenAsync(token.RefreshToken, user);

        return ServiceResult<TokenDto>.SuccessAsCreated(token, " ");
    }
}