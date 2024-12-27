using CourseMarket.Domain.Entities;

namespace CourseMarket.Application.Interfaces.Repositories;

public interface IOrderRepository : IRepository<Order, Guid>
{
}