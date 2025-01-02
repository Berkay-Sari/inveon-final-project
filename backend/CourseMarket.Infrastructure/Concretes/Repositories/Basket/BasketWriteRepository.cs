using CourseMarket.Application.Interfaces.Repositories.Basket;
using CourseMarket.Infrastructure.Context;

namespace CourseMarket.Infrastructure.Concretes.Repositories.Basket;

public class BasketWriteRepository(AppDbContext context)
    : WriteRepository<Domain.Entities.Basket, Guid>(context), IBasketWriteRepository;