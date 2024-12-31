using System;
using System.Collections.Generic;
using System.Linq;
using CourseMarket.Application.Interfaces.Storage;
using Microsoft.AspNetCore.Http;

namespace CourseMarket.Infrastructure.Concretes.Services.Storage.Azure;

public class AzureStorage : Storage, IStorage //IAzureStorage olur eklersek
{
    public Task<(string fileName, string pathOrContainerName)> UploadAsync(string containerName, IFormFile file)
    {
        throw new NotImplementedException();
    }
    public Task DeleteAsync(string containerName, string fileName)
    {
        throw new NotImplementedException();
    }

    public string? GetFile(string containerName)
    {
        throw new NotImplementedException();
    }

    public bool HasFile(string containerName, string fileName)
    {
        throw new NotImplementedException();
    }
}