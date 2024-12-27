using CourseMarket.Application.Interfaces.Repositories;
using CourseMarket.Domain.Entities;
using CourseMarket.Infrastructure.Context;

namespace CourseMarket.Infrastructure.Repositories;

public class CourseRepository(AppDbContext context) : GenericRepository<Course, Guid>(context), ICourseRepository;