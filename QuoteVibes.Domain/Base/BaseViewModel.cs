namespace QuoteVibes.Domain.Base
{
    public class BaseViewModel
    {
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
        public string OrderBy { get; set; }
        public bool Asceending { get; set; } = false;
    }
}
