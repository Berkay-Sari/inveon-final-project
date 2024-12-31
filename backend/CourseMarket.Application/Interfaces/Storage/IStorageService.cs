using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseMarket.Application.Interfaces.Storage;

public interface IStorageService : IStorage
{
    public string StorageType { get; }
}