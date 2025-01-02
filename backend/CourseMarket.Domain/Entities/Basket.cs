using CourseMarket.Domain.Common;

namespace CourseMarket.Domain.Entities;

public class Basket : BaseEntity<Guid>
{
    public Guid UserId { get; set; }
    public AppUser User { get; set; }
    public Order Order { get; set; }
    public List<BasketItem> Items { get; set; } = [];
    public decimal TotalPrice => Items.Sum(x => x.Price);
}
