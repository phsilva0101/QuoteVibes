using QuoteVibes.Domain.Entities.Pensamentos;

namespace QuoteVibes.Domain.ViewModels.Pensamento
{
    public class PensamentosInsertViewModel
    {
        public string Conteudo { get; set; }
        public string Autor { get; set; }
        public string Modelo { get; set; }
    }

    public static class PensamentosInsertViewModelExtensions
    {

        public static Pensamentos ToEntity(this PensamentosInsertViewModel entity)
        {
            return new Pensamentos
            {
                Conteudo = entity.Conteudo,
                Autor = entity.Autor,
                Modelo = entity.Modelo
            };
        }
    }
}
