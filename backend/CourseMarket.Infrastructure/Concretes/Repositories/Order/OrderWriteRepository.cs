using CourseMarket.Application.Interfaces.Repositories.Order;
using CourseMarket.Infrastructure.Context;

namespace CourseMarket.Infrastructure.Concretes.Repositories.Order;
public class OrderWriteRepository(AppDbContext context)
    : WriteRepository<Domain.Entities.Order, Guid>(context), IOrderWriteRepository;