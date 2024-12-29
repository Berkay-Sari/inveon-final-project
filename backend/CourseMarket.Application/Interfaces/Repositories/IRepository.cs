using System.Linq.Expressions;
using CourseMarket.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace CourseMarket.Application.Interfaces.Repositories;

public interface IRepository<T, in TId> where T : BaseEntity<TId> where TId : struct
{
    DbSet<T> Table { get; }
}