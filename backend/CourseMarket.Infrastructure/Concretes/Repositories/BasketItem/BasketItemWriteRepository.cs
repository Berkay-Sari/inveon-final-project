using CourseMarket.Application.Interfaces.Repositories.BasketItem;
using CourseMarket.Infrastructure.Context;

namespace CourseMarket.Infrastructure.Concretes.Repositories.BasketItem;
public class BasketItemWriteRepository(AppDbContext context)
    : WriteRepository<Domain.Entities.BasketItem, Guid>(context), IBasketItemWriteRepository;
