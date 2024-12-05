using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ArcheologicalSite.Interfaces;

namespace ArcheologicalSite.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class, IEntity
    {
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>>? filter = null);
        Task<TEntity> GetById(Guid id);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(ICollection<TEntity> entity);
        Task Delete(TEntity entity);
        Task Update(TEntity entity);
    }
}