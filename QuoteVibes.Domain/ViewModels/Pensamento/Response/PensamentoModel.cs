using QuoteVibes.Domain.Entities.Pensamentos;

namespace QuoteVibes.Domain.ViewModels.Pensamento.Response
{
    public class PensamentoModel
    {
        public Guid Id { get; set; }
        public string Conteudo { get; set; }
        public string Autor { get; set; }
        public string Modelo { get; set; }


    }

    public static class PensamentoModelExtensions
    {
        public static PensamentoModel ToMapModel(this Pensamentos entity)
        {
            return new PensamentoModel
            {
                Id = entity.Id,
                Conteudo = entity.Conteudo,
                Autor = entity.Autor,
                Modelo = entity.Modelo
            };
        }

        public static IEnumerable<PensamentoModel> ToMapModel(this IEnumerable<Pensamentos> entities)
        {
            return entities.Select(ToMapModel);
        }

        public static IEnumerable<PensamentoModel> ToMapModel(this IReadOnlyList<Pensamentos> entities)
        {
            return entities.Select(ToMapModel);
        }

        public static Pensamentos ToEntity(this PensamentoModel entity)
        {
            return new Pensamentos
            {
                Id = entity.Id,
                Conteudo = entity.Conteudo,
                Autor = entity.Autor,
                Modelo = entity.Modelo
            };
        }
    }
}
