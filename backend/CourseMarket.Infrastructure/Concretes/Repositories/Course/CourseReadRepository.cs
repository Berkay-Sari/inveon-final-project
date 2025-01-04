using CourseMarket.Application.Interfaces.Repositories.Course;
using CourseMarket.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CourseMarket.Infrastructure.Concretes.Repositories.Course;

public class CourseReadRepository(AppDbContext context)
    : ReadRepository<Domain.Entities.Course, Guid>(context), ICourseReadRepository
{
    public async Task<List<Domain.Entities.Course>> GetRange(List<Guid> idList)
    {
        return await Table
            .Where(course => idList.Contains(course.Id))
            .ToListAsync();
    }
}