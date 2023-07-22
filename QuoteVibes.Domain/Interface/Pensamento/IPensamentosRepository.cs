using QuoteVibes.Domain.Base;
using QuoteVibes.Domain.Entities.Pensamentos;

namespace QuoteVibes.Domain.Interface.Pensamento
{
    public interface IPensamentosRepository : IBaseRepository<Pensamentos, Guid>
    {
    }
}
