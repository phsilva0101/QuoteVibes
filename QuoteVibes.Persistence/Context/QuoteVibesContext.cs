using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using QuoteVibes.Domain.Base;
using QuoteVibes.Domain.Entities.Pensamentos;

namespace QuoteVibes.Persistence.Context
{
    public class QuoteVibesContext : DbContext
    {
        public QuoteVibesContext(DbContextOptions<QuoteVibesContext> options) : base(options)
        {
        }

        public DbSet<Pensamentos> Pensamentos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(QuoteVibesContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            BeforeSave();

            return base.SaveChangesAsync(cancellationToken);
        }

        private void BeforeSave()
        {

            IEnumerable<EntityEntry> changedEntities = ChangeTracker.Entries();

            foreach (EntityEntry changedEntity in changedEntities)
            {
                if (changedEntity.State is EntityState.Detached or EntityState.Unchanged)
                {
                    continue;
                }

                if (changedEntity.Entity is BaseEntity entity)
                {
                    switch (changedEntity.State)
                    {
                        case EntityState.Added:
                            if (entity.Id == Guid.Empty)
                            {
                                entity.Id = Guid.NewGuid();
                            }

                            entity.DataRegistro = DateTime.Now;
                            entity.DataAtualizacao = DateTime.Now;
                            break;

                        case EntityState.Modified:
                            entity.DataAtualizacao = DateTime.Now;
                            break;
                    }
                }
            }
        }
    }
}