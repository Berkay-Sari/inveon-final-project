using CourseMarket.Application.Interfaces.Repositories.CourseImageFile;
using CourseMarket.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CourseMarket.Infrastructure.Concretes.Repositories.CourseImageFile;

public class CourseImageFileReadRepository(AppDbContext context)
    : ReadRepository<Domain.Entities.CourseImageFile, Guid>(context), ICourseImageFileReadRepository
{
    public Task<Domain.Entities.CourseImageFile?> GetByCourseIdAsync(Guid courseId)
    {
        return Table.FirstOrDefaultAsync(x => x.CourseId == courseId);
    }
}