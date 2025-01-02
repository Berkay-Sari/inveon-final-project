using System.ComponentModel.DataAnnotations;
using CourseMarket.Domain.Common;

namespace CourseMarket.Domain.Entities;

public class Course : BaseEntity<Guid>, IAuditEntity
{
    [MaxLength(100)] public required string Name { get; set; }

    [MaxLength(500)] public string? Description { get; set; }

    [Required] public required decimal Price { get; set; }

    [MaxLength(50)] public required string Category { get; set; }

    public Guid InstructorId { get; set; }

    // Navigation Properties
    public AppUser? Instructor { get; set; }
    public CourseImageFile Image { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}