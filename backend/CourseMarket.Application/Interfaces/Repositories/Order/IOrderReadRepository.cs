namespace CourseMarket.Application.Interfaces.Repositories.Order;

public interface IOrderReadRepository : IReadRepository<Domain.Entities.Order, Guid>
{
    Task<Domain.Entities.Order?> GetUncompletedOrderByUserIdAsync(Guid userId);

    Task<List<Domain.Entities.Order>> GetCompletedOrdersByUserIdAsync(Guid userId);
}
