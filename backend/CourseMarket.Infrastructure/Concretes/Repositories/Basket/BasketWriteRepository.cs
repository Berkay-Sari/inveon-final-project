using CourseMarket.Application.Interfaces.Repositories.Basket;
using CourseMarket.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CourseMarket.Infrastructure.Concretes.Repositories.Basket;

public class BasketWriteRepository(AppDbContext context)
    : WriteRepository<Domain.Entities.Basket, Guid>(context), IBasketWriteRepository
{
    public void DeleteByUserId(Guid userId)
    {
        var basketsToDelete = Table.Where(basket => basket.UserId == userId);

        Table.RemoveRange(basketsToDelete);
    }
}