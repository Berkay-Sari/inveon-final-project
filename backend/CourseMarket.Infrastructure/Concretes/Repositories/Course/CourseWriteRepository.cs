using CourseMarket.Application.Interfaces.Repositories.Course;
using CourseMarket.Infrastructure.Context;

namespace CourseMarket.Infrastructure.Concretes.Repositories.Course;

public class CourseWriteRepository(AppDbContext context) : WriteRepository<Domain.Entities.Course, Guid>(context), ICourseWriteRepository;