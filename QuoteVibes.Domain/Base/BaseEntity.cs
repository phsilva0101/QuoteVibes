namespace QuoteVibes.Domain.Base
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime DataRegistro { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public DateTime? DataDesativacao { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
            DataAtualizacao = DateTime.Now;
            DataRegistro = DateTime.Now;
        }
    }
}
