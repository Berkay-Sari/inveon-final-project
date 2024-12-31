using CourseMarket.Application.Interfaces.Repositories.CourseImageFile;
using CourseMarket.Infrastructure.Context;

namespace CourseMarket.Infrastructure.Concretes.Repositories.CourseImageFile;

public class CourseImageFileReadRepository(AppDbContext context)
    : ReadRepository<Domain.Entities.CourseImageFile, Guid>(context), ICourseImageFileReadRepository;