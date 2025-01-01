using CourseMarket.Application.DTOs.Token;
using CourseMarket.Domain.Entities;

namespace CourseMarket.Application.Interfaces.Services;

public interface ITokenService
{
    TokenDto CreateAccessToken(AppUser user);
}
