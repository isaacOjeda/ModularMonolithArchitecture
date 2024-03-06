using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modular.eShop.Infrastructure.Configuration;

namespace Modular.eShop.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection InstallServicesFromAssemblies(
        this IServiceCollection services,
        IConfiguration configuration,
        params Assembly[] assemblies)
    {
        var serviceInstallers = InstanceFactory.CreateFromAssemblies<IServiceInstaller>(assemblies);

        foreach (var serviceInstaller in serviceInstallers)
        {
            serviceInstaller.Install(services, configuration);
        }

        return services;
    }

    public static IServiceCollection InstallModulesFromAssemblies(
        this IServiceCollection services,
        IConfiguration configuration,
        params Assembly[] assemblies)
    {
        var moduleInstallers = InstanceFactory.CreateFromAssemblies<IModuleInstaller>(assemblies);

        foreach (var moduleInstaller in moduleInstallers)
        {
            moduleInstaller.Install(services, configuration);
        }

        return services;
    }
}
