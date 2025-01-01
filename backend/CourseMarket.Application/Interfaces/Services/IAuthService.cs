using CourseMarket.Application.DTOs.Token;
using CourseMarket.Application.DTOs.User;
using CourseMarket.Application.Wrappers;

namespace CourseMarket.Application.Interfaces.Services;

public interface IAuthService
{
    Task<ServiceResult<TokenDto>> LoginAsync(LoginRequest loginRequest);

    Task<ServiceResult<TokenDto>> RefreshTokenLoginAsync(string refreshToken);
}
