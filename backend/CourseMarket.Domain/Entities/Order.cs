using CourseMarket.Domain.Common;

namespace CourseMarket.Domain.Entities;

public class Order : BaseEntity<Guid>
{
    public Guid BuyerId { get; set; }

    public Guid CourseId { get; set; }

    public DateTime OrderDate { get; set; }

    // Navigation Properties
    public AppUser? Buyer { get; set; }
    public Course? Course { get; set; }
    public Payment? Payment { get; set; }
}