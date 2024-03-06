using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Modular.eShop.Catalogs.Application.Common.Interfaces;
using Modular.eShop.Catalogs.Persistence;
using Modular.eShop.Infrastructure.Configuration;
using Modular.eShop.Persistence.Interceptors;

namespace Modular.eShop.Catalogs.Infrastructure.ServiceInstallers;
internal class PersistenceServiecInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.TryAddSingleton<UpdateAuditableEntitiesInterceptor>();

        services.AddDbContext<CatalogDbContext>((serviceProvider, options) =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Catalogs"));
            options.AddInterceptors(serviceProvider.GetRequiredService<UpdateAuditableEntitiesInterceptor>());
        });

        services.AddScoped<ICatalogDbContext>(services => services.GetRequiredService<CatalogDbContext>());
    }
}
