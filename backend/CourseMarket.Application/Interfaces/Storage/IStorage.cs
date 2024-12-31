using Microsoft.AspNetCore.Http;

namespace CourseMarket.Application.Interfaces.Storage;

public interface IStorage
{
    Task<(string fileName, string pathOrContainerName)> UploadAsync(string pathOrContainerName, IFormFile file);

    Task DeleteAsync(string pathOrContainerName, string fileName);

    string? GetFile(string pathOrContainerName);

    bool HasFile(string pathOrContainerName, string fileName);
}