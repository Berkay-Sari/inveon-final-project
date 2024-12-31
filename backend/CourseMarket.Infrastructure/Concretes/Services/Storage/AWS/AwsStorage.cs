using CourseMarket.Application.Interfaces.Storage;
using Microsoft.AspNetCore.Http;

namespace CourseMarket.Infrastructure.Concretes.Services.Storage.AWS;
public class AwsStorage : Storage, IStorage //IAwsStorage
{
    public Task<(string fileName, string pathOrContainerName)> UploadAsync(string pathOrContainerName, IFormFile file)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(string pathOrContainerName, string fileName)
    {
        throw new NotImplementedException();
    }

    public string? GetFile(string pathOrContainerName)
    {
        throw new NotImplementedException();
    }

    public bool HasFile(string pathOrContainerName, string fileName)
    {
        throw new NotImplementedException();
    }
}

