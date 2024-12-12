using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EventPlanner.Interfaces;

namespace EventPlanner.Repositories;
public interface IRepositoryBase<TEntity> where TEntity : class, IEntity
{
    Task<List<TEntity>> Get(Expression<Func<TEntity, bool>>? filter = null);
    Task<TEntity> GetById(Guid id);
    Task AddAsync(TEntity entity);
    Task Delete(TEntity entity);
    Task Update(TEntity entity);
}