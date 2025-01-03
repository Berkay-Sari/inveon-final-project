using CourseMarket.Application.Interfaces.Storage.Local;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CourseMarket.Infrastructure.Concretes.Services.Storage.Local;

public class LocalStorage(IWebHostEnvironment webHostEnvironment, ILogger<LocalStorage> logger) : Storage, ILocalStorage
{
    public async Task<(string fileName, string pathOrContainerName)> UploadAsync(string path, IFormFile file)
    {
        var uploadPath = Path.Combine(webHostEnvironment.WebRootPath, path);

        if (!Directory.Exists(uploadPath))
        {
            Directory.CreateDirectory(uploadPath);
        }

        //Search Engine Optimization(SEO) ve Collision olmamasi icin dosya adi degistirme
        var newFileName = Rename(uploadPath, file.FileName, HasFile);
        var result = await CopyAsync(Path.Combine(uploadPath, newFileName), file);

        if (!result)
        {
            throw new Exception("File upload failed");
        }

        return (newFileName, Path.Combine(path, newFileName));
    }

    public async Task DeleteAsync(string path, string fileName) => await Task.Run(() =>
    {
        var filePath = Path.Combine(webHostEnvironment.WebRootPath, path, fileName);
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    });

    public string? GetFile(string path)
    {
        var filePath = Path.Combine(webHostEnvironment.WebRootPath, path);
        return File.Exists(filePath) ? filePath : null;
    }

    public new bool HasFile(string path, string fileName) =>
        File.Exists(Path.Combine(webHostEnvironment.WebRootPath, path, fileName));

    private async Task<bool> CopyAsync(string path, IFormFile file)
    {
        try
        {
            await using FileStream fileStream = new(path,
                FileMode.Create,
                FileAccess.Write,
                FileShare.None,
                bufferSize: 1024 * 1024,
                useAsync: false);

            await file.CopyToAsync(fileStream);
            await fileStream.FlushAsync();
            return true;
        }
        catch (Exception ex)
        {
            logger.LogError(ex,
                "File copy failed. Could be due to permission issues, disk space problems, or a corrupt file. Path: {Path}, FileName: {FileName}",
                path, file.FileName);
            throw;
        }
    }
}