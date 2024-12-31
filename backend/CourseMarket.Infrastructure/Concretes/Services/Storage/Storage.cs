using CourseMarket.Infrastructure.Operations;

namespace CourseMarket.Infrastructure.Concretes.Services.Storage;

public class Storage
{
    protected delegate bool HasFile(string pathOrContainer, string fileName);
    protected string Rename(string pathOrContainer, string fileName, HasFile hasFileMethod)
    {
        var extension = Path.GetExtension(fileName);
        var oldName = Path.GetFileNameWithoutExtension(fileName);
        var newName = $"{NameOperation.SanitizeName(oldName)}{extension}";

        var iteration = 0;

        // Azure'da farklı Local'de farklı exist kontrolü yapıldığı için bu şekilde bir delege yapısı oluşturuldu.
        while (hasFileMethod(pathOrContainer, newName))
        {
            newName = $"{NameOperation.SanitizeName(oldName)}_{++iteration}{extension}";
        }

        return newName;
    }
}
