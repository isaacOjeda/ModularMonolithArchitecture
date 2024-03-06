using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modular.eShop.Application.Behaviors;
using Modular.eShop.Infrastructure.Configuration;

namespace Modular.eShop.Catalogs.Infrastructure.ServiceInstallers;
internal sealed class ApplicationServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Application.AssemblyReference.Assembly);
            config.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));
        });

        services.AddValidatorsFromAssembly(Application.AssemblyReference.Assembly, includeInternalTypes: true);
    }
}
