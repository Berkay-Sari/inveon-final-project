using CourseMarket.Application.Interfaces.Repositories;
using CourseMarket.Domain.Entities;
using CourseMarket.Infrastructure.Context;

namespace CourseMarket.Infrastructure.Repositories;

public class OrderRepository(AppDbContext context) : GenericRepository<Order, Guid>(context), IOrderRepository
{
}