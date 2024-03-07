using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modular.eShop.Infrastructure.Configuration;

namespace Modular.eShop.Catalogs.Infrastructure.ServiceInstallers;
internal class EndpointsServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddFastEndpoints(options =>
        {
            options.Assemblies = [Endpoints.AssemblyReference.Assembly];
        })
        .SwaggerDocument(o =>
        {
            o.AutoTagPathSegmentIndex = 2;
        });
    }
}
