using QuoteVibes.Domain.Base;
using QuoteVibes.Persistence.Context;

namespace QuoteVibes.Persistence.Repositories.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly QuoteVibesContext _context;

        public UnitOfWork(QuoteVibesContext context)
        {
            _context = context;
        }

        public async Task CommitarTransacaoAsync(CancellationToken cancellationToken = default)
        {
            if (_context.ChangeTracker.HasChanges())
                await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
