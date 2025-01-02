using System.Linq.Expressions;
using CourseMarket.Domain.Common;

namespace CourseMarket.Application.Interfaces.Repositories;

// SOLID: I - Interface Segregation Principle (ISP)
public interface IReadRepository<T, in TId> : IRepository<T, TId>
    where T : BaseEntity<TId>
    where TId : struct
{
    IQueryable<T> GetAll(bool tracking = false);

    IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate, bool tracking = false);

    Task<T?> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = false);

    Task<T?> GetByIdAsync(TId id, bool tracking = false);

    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
}