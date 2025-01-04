using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace CourseMarket.Infrastructure.Context;

public static class UserContext
{
    public static Guid GetUserId(IHttpContextAccessor httpContextAccessor)
    {
        var userId = httpContextAccessor?.HttpContext?.User?.Claims
            .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId))
        {
            throw new Exception("User ID not found in the token");
        }

        return Guid.Parse(userId);
    }
}