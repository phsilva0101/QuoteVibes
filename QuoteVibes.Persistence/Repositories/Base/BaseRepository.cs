using Microsoft.EntityFrameworkCore;
using QuoteVibes.Domain.Base;
using QuoteVibes.Persistence.Context;

namespace QuoteVibes.Persistence.Repositories.Base
{
    public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : class where TKey : struct
    {

        protected readonly QuoteVibesContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(QuoteVibesContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entidade)
        {
            await _dbSet.AddAsync(entidade);
            return entidade;
        }

        public async Task<bool> DeleteAsync(TKey key)
        {
            var entity = await _dbSet.FindAsync(key);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                return true;
            }

            return false;

        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetAsync(TKey key)
        {
            return await _dbSet.FindAsync(key);
        }

        public TEntity Update(TEntity entidade)
        {
            _dbSet.Update(entidade);
            return entidade;
        }
    }
}
