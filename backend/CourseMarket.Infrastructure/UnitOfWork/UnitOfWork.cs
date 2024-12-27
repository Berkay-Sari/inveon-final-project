using CourseMarket.Application.Interfaces.UnitOfWork;
using CourseMarket.Infrastructure.Context;

namespace CourseMarket.Infrastructure.UnitOfWork;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return context.SaveChangesAsync(cancellationToken);
    }
}