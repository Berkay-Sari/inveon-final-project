using CourseMarket.Application.Interfaces.Repositories.File;
using CourseMarket.Infrastructure.Context;

namespace CourseMarket.Infrastructure.Concretes.Repositories.File;

public class FileReadRepository(AppDbContext context) 
    : ReadRepository<Domain.Entities.File, Guid>(context), IFileReadRepository;