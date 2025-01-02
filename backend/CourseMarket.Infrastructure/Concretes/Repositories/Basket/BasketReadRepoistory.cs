using CourseMarket.Application.Interfaces.Repositories.Basket;
using CourseMarket.Infrastructure.Context;

namespace CourseMarket.Infrastructure.Concretes.Repositories.Basket;

public class BasketReadRepository(AppDbContext context)
    : ReadRepository<Domain.Entities.Basket, Guid>(context), IBasketReadRepository;
