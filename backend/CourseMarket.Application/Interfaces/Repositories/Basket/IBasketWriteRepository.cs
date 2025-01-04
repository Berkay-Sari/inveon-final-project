namespace CourseMarket.Application.Interfaces.Repositories.Basket;

public interface IBasketWriteRepository : IWriteRepository<Domain.Entities.Basket, Guid>
{
    void DeleteByUserId(Guid userId);
}