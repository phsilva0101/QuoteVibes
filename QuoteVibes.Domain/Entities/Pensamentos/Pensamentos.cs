using QuoteVibes.Domain.Base;

namespace QuoteVibes.Domain.Entities.Pensamentos
{
    public class Pensamentos : BaseEntity
    {
        public string Conteudo { get; set; }
        public string Autor { get; set; }
        public string Modelo { get; set; }

    }
}
