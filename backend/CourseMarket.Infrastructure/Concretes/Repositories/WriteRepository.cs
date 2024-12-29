using CourseMarket.Application.Interfaces.Repositories;
using CourseMarket.Domain.Common;
using CourseMarket.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CourseMarket.Infrastructure.Concretes.Repositories;

public class WriteRepository<T, TId>(AppDbContext context) : IWriteRepository<T, TId>
    where T : BaseEntity<TId>
    where TId : struct
{
    public DbSet<T> Table => context.Set<T>();

    public async Task<bool> AddAsync(T entity)
    {
        var entityEntry = await Table.AddAsync(entity);
        return entityEntry.State == EntityState.Added;
    }

    public bool Update(T entity)
    {
        var entityEntry = Table.Update(entity);
        return entityEntry.State == EntityState.Modified;
    }

    public bool Delete(T entity)
    {
        var entityEntry = Table.Remove(entity);
        return entityEntry.State == EntityState.Deleted;
    }

    public async Task<bool> DeleteByIdAsync(TId id)
    {
        var entity = await Table.FindAsync(id);
        return entity != null && Delete(entity);
    }
}