using CourseMarket.Domain.Entities;

namespace CourseMarket.Application.Interfaces.Repositories;

public interface ICourseRepository : IRepository<Course, Guid>
{
}