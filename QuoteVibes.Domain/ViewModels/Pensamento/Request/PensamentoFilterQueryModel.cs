using QuoteVibes.Domain.Base;

namespace QuoteVibes.Domain.ViewModels.Pensamento.Request
{
    public class PensamentoFilterQueryModel : BaseViewModel
    {
        public string? Conteudo { get; set; }
        public string? Autor { get; set; }
    }
}
