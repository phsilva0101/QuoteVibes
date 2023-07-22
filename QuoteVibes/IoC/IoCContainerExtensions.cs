using QuoteVibes.Domain.Base;
using QuoteVibes.Domain.Interface.Pensamento;
using QuoteVibes.Persistence.Repositories.Base;
using QuoteVibes.Persistence.Repositories.Pensamento;

namespace QuoteVibes.IoC
{
    public static class IoCContainerExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPensamentosRepository, PensamentosRepository>();
        }
    }
}
