using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using CourseMarket.Domain.Common;

namespace CourseMarket.Domain.Entities;

public class Order : BaseEntity<Guid>, IAuditEntity
{
    private Order()
    {
    }

    public Order(Guid userId, List<Guid> courseIds, decimal totalAmount)
    {
        CreateNew(userId, courseIds, totalAmount);
    }

    public Guid UserId { get; private set; }

    [Required]
    [MaxLength(5000)]
    public string CourseIds { get; private set; } // JSON string for storing course IDs as a list

    public decimal TotalAmount { get; set; }

    public bool IsCompleted { get; private set; }

    public string? OrderCode { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    // Navigation Properties
    public AppUser? User { get; set; }

    public List<Guid> GetCourseIds()
    {
        return JsonSerializer.Deserialize<List<Guid>>(CourseIds) ?? new List<Guid>();
    }

    public void CreateNew(Guid userId, List<Guid> courseIds, decimal totalAmount)
    {
        if (totalAmount <= 0) throw new InvalidOperationException("Total amount must be greater than zero.");

        UserId = userId;
        CourseIds = JsonSerializer.Serialize(courseIds);
        TotalAmount = totalAmount;
        IsCompleted = false;
    }

    public void UpdateCourseIds(List<Guid> courseIds)
    {
        CourseIds = JsonSerializer.Serialize(courseIds);
    }

    public void CompleteOrder(string orderCode)
    {
        IsCompleted = true;
        OrderCode = orderCode;
    }
}