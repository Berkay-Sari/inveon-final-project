using CourseMarket.Application.Interfaces.Repositories.File;
using CourseMarket.Infrastructure.Context;

namespace CourseMarket.Infrastructure.Concretes.Repositories.File;

public class FileWriteRepository(AppDbContext context) 
    : WriteRepository<Domain.Entities.File, Guid>(context), IFileWriteRepository;
