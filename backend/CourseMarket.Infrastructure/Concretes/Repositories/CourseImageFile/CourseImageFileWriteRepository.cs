using CourseMarket.Application.Interfaces.Repositories.CourseImageFile;
using CourseMarket.Infrastructure.Context;

namespace CourseMarket.Infrastructure.Concretes.Repositories.CourseImageFile;

public class CourseImageFileWriteRepository(AppDbContext context) 
    : WriteRepository<Domain.Entities.CourseImageFile, Guid>(context), ICourseImageFileWriteRepository;