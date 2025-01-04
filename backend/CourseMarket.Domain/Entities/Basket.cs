using CourseMarket.Domain.Common;

namespace CourseMarket.Domain.Entities;

public class Basket : BaseEntity<Guid>
{
    private Basket()
    {
    }

    public Basket(Guid userId, Guid courseId)
    {
        UserId = userId;
        CourseId = courseId;
    }

    public Guid UserId { get; private set; }
    public Guid CourseId { get; private set; }

    // Navigation Properties
    public AppUser? User { get; set; }
    public Course? Course { get; set; }
}