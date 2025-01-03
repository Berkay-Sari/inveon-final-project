namespace CourseMarket.Application.Interfaces.Repositories.CourseImageFile;

public interface ICourseImageFileReadRepository : IReadRepository<Domain.Entities.CourseImageFile, Guid>
{
    Task<Domain.Entities.CourseImageFile?> GetByCourseIdAsync(Guid courseId);
}