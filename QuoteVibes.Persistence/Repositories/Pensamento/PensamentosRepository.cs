using Microsoft.EntityFrameworkCore;
using QuoteVibes.CrossCutting.Util;
using QuoteVibes.Domain.Entities.Pensamentos;
using QuoteVibes.Domain.Interface.Pensamento;
using QuoteVibes.Domain.ViewModels.Pensamento.Request;
using QuoteVibes.Domain.ViewModels.Pensamento.Response;
using QuoteVibes.Persistence.Context;
using QuoteVibes.Persistence.Repositories.Base;

namespace QuoteVibes.Persistence.Repositories.Pensamento
{
    public class PensamentosRepository : BaseRepository<Pensamentos, Guid>, IPensamentosRepository
    {
        public PensamentosRepository(QuoteVibesContext context) : base(context)
        {
        }

        public async Task<(long count, IReadOnlyList<PensamentoModel> models)> ObterTodosAsync(PensamentoFilterQueryModel filterQueryModel, CancellationToken cancellationToken = default)
        {
            var query = _context.Pensamentos.Where(x => x.DataDesativacao == null).AsQueryable();

            if (!string.IsNullOrEmpty(filterQueryModel.Conteudo))
                query = query.Where(x => x.Conteudo.Contains(filterQueryModel.Conteudo));

            if (!string.IsNullOrEmpty(filterQueryModel.Autor))
                query = query.Where(x => x.Autor.Contains(filterQueryModel.Autor));

            if (!string.IsNullOrWhiteSpace(filterQueryModel.OrderBy))
                query = query.OrderByDynamic(filterQueryModel.OrderBy, filterQueryModel.Asceending);
            else
                query = query.OrderByDescending(x => x.DataRegistro);

            var count = await query.LongCountAsync(cancellationToken);

            var models = await query
                .Skip((filterQueryModel.PageNumber - 1) * filterQueryModel.PageSize)
                .Take(filterQueryModel.PageSize)
                .Select(x => new PensamentoModel
                {
                    Id = x.Id,
                    Conteudo = x.Conteudo,
                    Autor = x.Autor,
                    Modelo = x.Modelo
                })
                .ToListAsync(cancellationToken);

            return (count, models);
        }
    }
}
