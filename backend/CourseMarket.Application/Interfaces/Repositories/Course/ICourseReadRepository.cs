namespace CourseMarket.Application.Interfaces.Repositories.Course;

public interface ICourseReadRepository : IReadRepository<Domain.Entities.Course, Guid>
{
    Task<List<Domain.Entities.Course>> GetRange(List<Guid> idList);
}