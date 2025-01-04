namespace CourseMarket.Application.Interfaces.Repositories.Basket;

public interface IBasketReadRepository : IReadRepository<Domain.Entities.Basket, Guid>
{
    Task<List<Guid>> GetCourseIdsByUserIdAsync(Guid userId);
    Task<Domain.Entities.Basket?> GetBasketItem(Guid userId, Guid courseId);
    Task<bool> ExistsAsync(Guid userId, Guid courseId);
}

