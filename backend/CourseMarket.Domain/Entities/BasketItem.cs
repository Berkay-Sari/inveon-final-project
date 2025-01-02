using CourseMarket.Domain.Common;

namespace CourseMarket.Domain.Entities;

public class BasketItem : BaseEntity<Guid>
{
    public Guid BasketId { get; set; }
    public Guid CourseId { get; set; }
    public string CourseName { get; set; }
    public string ImageUrl { get; set; }
    public decimal Price { get; set; }

    public Basket Basket { get; set; }
    public Course Course { get; set; }

}

