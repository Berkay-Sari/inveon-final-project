using CourseMarket.Application.Interfaces.Repositories.Course;
using CourseMarket.Infrastructure.Context;

namespace CourseMarket.Infrastructure.Concretes.Repositories.Course;

public class CourseReadRepository(AppDbContext context) : ReadRepository<Domain.Entities.Course, Guid>(context), ICourseReadRepository;