namespace CourseMarket.Domain.Common;

public interface IAuditEntity
{
    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }
}