using CourseMarket.Application.Interfaces.Repositories;
using CourseMarket.Application.Interfaces.Repositories.Course;
using CourseMarket.Application.Interfaces.Repositories.CourseImageFile;
using CourseMarket.Application.Interfaces.Repositories.File;
using CourseMarket.Application.Interfaces.Services;
using CourseMarket.Application.Interfaces.Storage;
using CourseMarket.Application.Interfaces.UnitOfWork;
using CourseMarket.Infrastructure.Concretes.Repositories;
using CourseMarket.Infrastructure.Concretes.Repositories.Course;
using CourseMarket.Infrastructure.Concretes.Repositories.CourseImageFile;
using CourseMarket.Infrastructure.Concretes.Repositories.File;
using CourseMarket.Infrastructure.Concretes.Services;
using CourseMarket.Infrastructure.Concretes.Services.Storage;
using CourseMarket.Infrastructure.Concretes.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace CourseMarket.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped(typeof(IReadRepository<,>), typeof(ReadRepository<,>));
        serviceCollection.AddScoped(typeof(IWriteRepository<,>), typeof(WriteRepository<,>));
        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

        serviceCollection.AddScoped<ICourseReadRepository, CourseReadRepository>();
        serviceCollection.AddScoped<ICourseWriteRepository, CourseWriteRepository>();
        serviceCollection.AddScoped<IFileWriteRepository, FileWriteRepository>();
        serviceCollection.AddScoped<IFileReadRepository, FileReadRepository>();
        serviceCollection.AddScoped<ICourseImageFileWriteRepository, CourseImageFileWriteRepository>();
        serviceCollection.AddScoped<ICourseImageFileReadRepository, CourseImageFileReadRepository>();

        serviceCollection.AddScoped<ICourseService, CourseService>();
        serviceCollection.AddScoped<IStorageService, StorageService>();
    }

    public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : Storage, IStorage
    {
        serviceCollection.AddScoped<IStorage, T>();
    }
}