using CourseMarket.Application.Interfaces.Repositories.BasketItem;
using CourseMarket.Infrastructure.Context;

namespace CourseMarket.Infrastructure.Concretes.Repositories.BasketItem;

public class BasketItemReadRepository(AppDbContext context)
   : ReadRepository<Domain.Entities.BasketItem, Guid>(context), IBasketItemReadRepository;
