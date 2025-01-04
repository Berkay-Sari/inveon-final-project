using System.ComponentModel.DataAnnotations;
using CourseMarket.Domain.Common;

namespace CourseMarket.Domain.Entities;

//rich domain model
public class Payment : BaseEntity<Guid>, IAuditEntity
{
    private Payment()
    {
    }

    public Payment(Guid userId, Guid orderId, decimal amount)
    {
        CreateNew(userId, orderId, amount);
    }

    public Guid UserId { get; private set; }
    public Guid OrderId { get; private set; }
    public decimal Amount { get; set; }
    public PaymentStatus Status { get; private set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    [MaxLength(500)] public string? Error { get; set; }

    // Navigation Properties
    public AppUser? User { get; set; }
    //public Order? Order { get; set; }

    public void CreateNew(Guid userId, Guid orderId, decimal amount)
    {
        ArgumentException.ThrowIfNullOrEmpty(orderId.ToString());

        if (amount <= 0) throw new InvalidOperationException("Payment amount must be greater than zero.");

        UserId = userId;
        OrderId = orderId;
        Amount = amount;
        Status = PaymentStatus.Pending;
    }

    public void SetSuccessStatus()
    {
        Status = PaymentStatus.Success;
    }

    public void SetFailStatus(string error)
    {
        Status = PaymentStatus.Fail;
        Error = error;
    }
}

public enum PaymentStatus
{
    Pending = 0,
    Success = 1,
    Fail = 2
}