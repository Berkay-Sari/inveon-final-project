using CourseMarket.Domain.Common;

namespace CourseMarket.Domain.Entities;

public class Order : BaseEntity<Guid>, IAuditEntity
{
    public int PaymentId { get; set; }
    public string Address { get; set; }

    public string OrderCode { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    // Navigation Properties
    public Payment? Payment { get; set; }
    public Basket Basket { get; set; }
}