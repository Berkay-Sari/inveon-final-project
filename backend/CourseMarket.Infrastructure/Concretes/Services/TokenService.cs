using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using CourseMarket.Application.DTOs.Token;
using CourseMarket.Application.Interfaces.Services;
using CourseMarket.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CourseMarket.Infrastructure.Concretes.Services;

public class TokenService(IConfiguration configuration, UserManager<AppUser> userManager) : ITokenService
{
    public TokenDto CreateAccessToken(AppUser user)
    {
        var token = new TokenDto();

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenOptions:SecurityKey"]!));

        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var ttlInHours = int.Parse(configuration["TokenOptions:AccessTokenExpiration"]!);

        token.Expiration = DateTime.Now.AddHours(ttlInHours);

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.UniqueName, user.UserName!)
        };

        var roles = userManager.GetRolesAsync(user);
        claims.AddRange(roles.Result.Select(role => new Claim(ClaimTypes.Role, role)));

        var jwtSecurityToken = new JwtSecurityToken(
            issuer: configuration["TokenOptions:Issuer"],
            audience: configuration["TokenOptions:Audience"],
            expires: token.Expiration,
            signingCredentials: credentials,
            claims: claims
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
