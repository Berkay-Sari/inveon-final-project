using CourseMarket.Application.Interfaces.Repositories.Basket;
using CourseMarket.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CourseMarket.Infrastructure.Concretes.Repositories.Basket;

public class BasketReadRepository(AppDbContext context)
    : ReadRepository<Domain.Entities.Basket, Guid>(context), IBasketReadRepository
{
    public async Task<List<Guid>> GetCourseIdsByUserIdAsync(Guid userId)
    {
        return await Table
            .Where(basket => basket.UserId == userId)
            .Select(basket => basket.CourseId)
            .ToListAsync();
    }
    public async Task<Domain.Entities.Basket?> GetBasketItem(Guid userId, Guid courseId)
    {
        return await Table
            .Where(basket => basket.UserId == userId && basket.CourseId == courseId)
            .FirstOrDefaultAsync();
    }


    public async Task<bool> ExistsAsync(Guid userId, Guid courseId)
    {
        return await Table
            .AnyAsync(basket => basket.UserId == userId && basket.CourseId == courseId);
    }
}
