using System.Linq.Expressions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace CulturalEvents.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class, IEntity
    {
        public readonly DbSet<TEntity> _dbSet;
        // com tph, a tabela, por ex, concert n existe
        public readonly AppDbContext _ctx;

        public RepositoryBase(AppDbContext appContext)
        {
            _dbSet = appContext.Set<TEntity>();
            _ctx = appContext;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _ctx.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            await _ctx.SaveChangesAsync();
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

        public async Task Update(TEntity entity)
        {
            _dbSet.Update(entity);
            await _ctx.SaveChangesAsync();
        }
    }
}