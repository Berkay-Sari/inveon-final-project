using CourseMarket.Application.Interfaces.Repositories.Order;
using CourseMarket.Infrastructure.Context;

namespace CourseMarket.Infrastructure.Concretes.Repositories.Order;

public class OrderReadRepository(AppDbContext context)
    : ReadRepository<Domain.Entities.Order, Guid>(context), IOrderReadRepository;
