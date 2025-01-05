using CourseMarket.Application.Interfaces.Repositories.Order;
using CourseMarket.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CourseMarket.Infrastructure.Concretes.Repositories.Order;

public class OrderReadRepository(AppDbContext context)
    : ReadRepository<Domain.Entities.Order, Guid>(context), IOrderReadRepository
{
    public Task<Domain.Entities.Order?> GetUncompletedOrderByUserIdAsync(Guid userId)
    {
        return Table
            .Where(order => order.UserId == userId && order.IsCompleted == false).FirstOrDefaultAsync();
    }

    public Task<List<Domain.Entities.Order>> GetCompletedOrdersByUserIdAsync(Guid userId)
    {
        return Table
            .Where(order => order.UserId == userId && order.IsCompleted == true).ToListAsync();
    }
}
