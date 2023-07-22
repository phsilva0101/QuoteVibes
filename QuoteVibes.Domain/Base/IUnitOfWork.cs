namespace QuoteVibes.Domain.Base
{
    public interface IUnitOfWork
    {
        Task CommitarTransacaoAsync(CancellationToken cancellationToken = default);
    }
}
