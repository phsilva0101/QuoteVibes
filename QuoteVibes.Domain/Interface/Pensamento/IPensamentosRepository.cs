using QuoteVibes.Domain.Base;
using QuoteVibes.Domain.Entities.Pensamentos;
using QuoteVibes.Domain.ViewModels.Pensamento.Request;
using QuoteVibes.Domain.ViewModels.Pensamento.Response;

namespace QuoteVibes.Domain.Interface.Pensamento
{
    public interface IPensamentosRepository : IBaseRepository<Pensamentos, Guid>
    {
        Task<(long count, IReadOnlyList<PensamentoModel> models)> ObterTodosAsync(PensamentoFilterQueryModel filterQueryModel, CancellationToken cancellationToken = default);
    }
}
