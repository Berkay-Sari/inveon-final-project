using CourseMarket.Application.Interfaces.UnitOfWork;
using CourseMarket.Infrastructure.Context;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task<int> CompleteAsync()
    {
        return await context.SaveChangesAsync();
    }
}