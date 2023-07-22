using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuoteVibes.Domain.Entities.Pensamentos;

namespace QuoteVibes.Persistence.ConfigurationMap
{
    public class PensamentosConfigMap : IEntityTypeConfiguration<Pensamentos>
    {
        public void Configure(EntityTypeBuilder<Pensamentos> builder)
        {
            builder.ToTable(nameof(Pensamentos));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Conteudo)
                .IsRequired()
                .HasMaxLength(1500);

            builder.Property(x => x.Autor).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Modelo).IsRequired().HasMaxLength(100);
        }
    }
}
