using CourseMarket.Domain.Common;

namespace CourseMarket.Domain.Entities;

public class Order : BaseEntity<Guid>, IAuditEntity
{
    public Guid BuyerId { get; set; }
    public int PaymentId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    // Navigation Properties
    public AppUser? Buyer { get; set; }
    public ICollection<Course> Courses { get; set; } = new List<Course>();
    public Payment? Payment { get; set; }
}