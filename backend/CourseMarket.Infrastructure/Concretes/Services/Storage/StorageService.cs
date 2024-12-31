using CourseMarket.Application.Interfaces.Storage;
using Microsoft.AspNetCore.Http;

namespace CourseMarket.Infrastructure.Concretes.Services.Storage;

public class StorageService(IStorage storage) : IStorageService
{
    public Task<(string fileName, string pathOrContainerName)> UploadAsync(string pathOrContainerName, IFormFile file)
    => storage.UploadAsync(pathOrContainerName, file);

    public Task DeleteAsync(string pathOrContainerName, string fileName)
    => storage.DeleteAsync(pathOrContainerName, fileName);

    public string? GetFile(string pathOrContainerName)
    => storage.GetFile(pathOrContainerName);

    public bool HasFile(string pathOrContainerName, string fileName)
    => storage.HasFile(pathOrContainerName, fileName);

    public string StorageType => storage.GetType().Name;
}
