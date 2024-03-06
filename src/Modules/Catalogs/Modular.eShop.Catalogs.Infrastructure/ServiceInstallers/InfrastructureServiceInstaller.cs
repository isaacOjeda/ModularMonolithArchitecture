using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Modular.eShop.Application.Time;
using Modular.eShop.Infrastructure.Configuration;
using Modular.eShop.Infrastructure.Time;

namespace Modular.eShop.Catalogs.Infrastructure.ServiceInstallers;
internal class InfrastructureServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.TryAddScoped<ISystemTime, SystemTime>();
    }
}
