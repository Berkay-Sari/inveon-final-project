﻿using System.Linq.Expressions;
using CourseMarket.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace CourseMarket.Application.Interfaces.Repositories;

public interface IRepository<T, in TId> where T : BaseEntity<TId> where TId : struct
{
    DbSet<T> Table { get; }
    IQueryable<T> GetAll();
    IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate);
    ValueTask<T?> GetByIdAsync(TId id);
    ValueTask<bool> AddAsync(T entity);
    bool Update(T entity);
    bool Delete(T entity);
    Task<bool> DeleteByIdAsync(TId id);
    Task<bool> ExistsAsync(TId id);
}