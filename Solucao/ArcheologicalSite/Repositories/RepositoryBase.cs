using System.Linq.Expressions;
using ArcheologicalSite.Context;
using ArcheologicalSite.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace ArcheologicalSite.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class, IEntity
    {
        public readonly DbSet<TEntity> _dbSet;
        public readonly AppDbContext _ctx;

        public RepositoryBase(AppDbContext appContext)
        {
            _dbSet = appContext.Set<TEntity>();
            _ctx = appContext;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(ICollection<TEntity> entity)
        {
            await _dbSet.AddRangeAsync(entity);
        }

        public Task Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>>? filter = null)
        {
            var query = _dbSet.AsQueryable();

            if (filter != null)
            {
                query = query
                    .Where(filter)
                    .AsNoTracking();
            }

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity is null)
            {
                throw new KeyNotFoundException();
            }

            return entity;
        }

        public Task Update(TEntity entity)
        {
            _dbSet.Update(entity);
            return Task.CompletedTask;
        }
    }
}