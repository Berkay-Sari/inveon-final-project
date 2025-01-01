using CourseMarket.Application.DTOs.User;
using CourseMarket.Application.Wrappers;
using CourseMarket.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace CourseMarket.Application.Interfaces.Services;

public interface IUserService
{
    Task<ServiceResult<IdentityResult>> CreateAsync(CreateUserRequest userDto);

    Task<ServiceResult> UpdateRefreshTokenAsync(string refreshToken, AppUser user);

}
