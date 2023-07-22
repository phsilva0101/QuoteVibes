using QuoteVibes.Domain.Entities.Pensamentos;
using QuoteVibes.Domain.Interface.Pensamento;
using QuoteVibes.Persistence.Context;
using QuoteVibes.Persistence.Repositories.Base;

namespace QuoteVibes.Persistence.Repositories.Pensamento
{
    public class PensamentosRepository : BaseRepository<Pensamentos, Guid>, IPensamentosRepository
    {
        public PensamentosRepository(QuoteVibesContext context) : base(context)
        {
        }
    }
}
