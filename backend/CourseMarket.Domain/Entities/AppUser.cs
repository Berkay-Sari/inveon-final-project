using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CourseMarket.Domain.Entities;

public class AppUser : IdentityUser<Guid>
{
    [MaxLength(50)] public required string FirstName { get; set; } = default!;

    [MaxLength(50)] public required string LastName { get; set; } = default!;

    public string? RefreshToken { get; set; }
    
    public DateTime? RefreshTokenExpiryTime { get; set; }

    public string FullName => $"{FirstName} {LastName}";

    // Navigation Properties
    public ICollection<Course>? GivenCourses { get; } = new List<Course>(); 
    public ICollection<Payment>? Payments { get; } = new List<Payment>();
    public ICollection<Basket> Baskets { get; set; }
}