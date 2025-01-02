using System.Linq.Expressions;
using CourseMarket.Application.Interfaces.Repositories;
using CourseMarket.Domain.Common;
using CourseMarket.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CourseMarket.Infrastructure.Concretes.Repositories;

public class ReadRepository<T, TId>(AppDbContext context) : IReadRepository<T, TId>
    where T : BaseEntity<TId>
    where TId : struct
{
    public DbSet<T> Table => context.Set<T>();

    public IQueryable<T> GetAll(bool tracking = false)
    {
        var query = Table.AsQueryable();
        if (!tracking) query = query.AsNoTracking();
        return query;
    }

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate, bool tracking = false)
    {
        var query = Table.Where(predicate);
        if (!tracking) query = query.AsNoTracking();
        return query;
    }
    public async Task<T?> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = false)
    {
        var query = Table.AsQueryable();
        if (!tracking)
            query = Table.AsNoTracking();
        return await query.FirstOrDefaultAsync(method);
    }
    public Task<T?> GetByIdAsync(TId id, bool tracking = false)
    {
        var query = Table.AsQueryable();
        if (!tracking) query = query.AsNoTracking();
        return query.FirstOrDefaultAsync(e => e.Id.Equals(id));
    }

    public Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
    {
        return Table.AnyAsync(predicate);
    }
}