using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using CourseMarket.Application.DTOs.Token;
using CourseMarket.Application.Interfaces.Services;
using CourseMarket.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CourseMarket.Infrastructure.Concretes.Services;

public class TokenService(IConfiguration configuration) : ITokenService
{
    public TokenDto CreateAccessToken(AppUser user)
    {
        var token = new TokenDto();

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenOptions:SecurityKey"]!));

        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

        var ttlInMinutes = int.Parse(configuration["TokenOptions:AccessTokenExpiration"]!);

        token.Expiration = DateTime.Now.AddHours(ttlInMinutes);

        var jwtSecurityToken = new JwtSecurityToken(
            issuer: configuration["TokenOptions:Issuer"],
            audience: configuration["TokenOptions:Audience"],
            expires: token.Expiration,
            signingCredentials: credentials,
            claims: new List<Claim> { new(ClaimTypes.Name, user.UserName!) }
        );

        var handler = new JwtSecurityTokenHandler();
        token.AccessToken = handler.WriteToken(jwtSecurityToken);
        token.RefreshToken = CreateRefreshToken();
        return token;
    }

    private static string CreateRefreshToken()
    {
        var numberByte = new byte[32];

        using var rnd = RandomNumberGenerator.Create();

        rnd.GetBytes(numberByte);

        return Convert.ToBase64String(numberByte);
    }

}
