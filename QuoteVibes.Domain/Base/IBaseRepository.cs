namespace QuoteVibes.Domain.Base
{
    public interface IBaseRepository<TEntity, TKey> where TEntity : class where TKey : struct
    {
        public Task<TEntity> AddAsync(TEntity entidade);
        public TEntity Update(TEntity entidade);
        public Task<bool> DeleteAsync(TKey key);
        public Task<TEntity> GetAsync(TKey key);
        public Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
