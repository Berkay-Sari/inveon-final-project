using CourseMarket.Domain.Common;

namespace CourseMarket.Domain.Entities;

public class File : BaseEntity<Guid>, IAuditEntity
{
    public string FileName { get; set; }
    public string Path { get; set; }
    public string Storage { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

}