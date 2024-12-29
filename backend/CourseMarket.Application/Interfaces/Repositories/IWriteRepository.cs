using CourseMarket.Domain.Common;

namespace CourseMarket.Application.Interfaces.Repositories;

// SOLID: I - Interface Segregation Principle (ISP)
public interface IWriteRepository<T, in TId> : IRepository<T, TId>
    where T : BaseEntity<TId>
    where TId : struct
{
    Task<bool> AddAsync(T entity);
    bool Update(T entity);
    bool Delete(T entity);
    Task<bool> DeleteByIdAsync(TId id);
}