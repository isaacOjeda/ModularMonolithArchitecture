using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modular.eShop.Infrastructure.Configuration;
using Modular.eShop.Infrastructure.Extensions;

namespace Modular.eShop.Catalogs.Infrastructure;

public sealed class CatalogsModuleInstaller : IModuleInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.InstallServicesFromAssemblies(configuration, AssemblyReference.Assembly);
    }
}
