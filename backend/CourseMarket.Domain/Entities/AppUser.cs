using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Microsoft.AspNetCore.Identity;

namespace CourseMarket.Domain.Entities;

public class AppUser : IdentityUser<Guid>
{
    [MaxLength(50)] public required string FirstName { get; set; } = default!;

    [MaxLength(50)] public required string LastName { get; set; } = default!;

    public string? RefreshToken { get; set; }
    
    public DateTime? RefreshTokenExpiryTime { get; set; }

    public string FullName => $"{FirstName} {LastName}";

    public string? PurchasedCourses { get; private set; }

    // Navigation Properties
    public ICollection<Course>? GivenCourses { get; } = new List<Course>(); 
    public ICollection<Payment>? Payments { get; } = new List<Payment>();

    public List<Guid> GetOwnedCourseIds()
    {
        if (PurchasedCourses == null)
        {
            return [];
        }
        return JsonSerializer.Deserialize<List<Guid>>(PurchasedCourses) ?? [];
    }

    public void AddCourseIds(List<Guid> courseIds)
    {
        var existingCourseIds = GetOwnedCourseIds() ?? [];

        foreach (var courseId in courseIds.Where(courseId => !existingCourseIds.Contains(courseId)))
        {
            existingCourseIds.Add(courseId);
        }

        PurchasedCourses = JsonSerializer.Serialize(existingCourseIds);
    }
}