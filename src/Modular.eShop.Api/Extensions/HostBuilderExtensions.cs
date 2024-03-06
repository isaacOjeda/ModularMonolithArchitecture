using Serilog;

namespace Modular.eShop.Api.Extensions;

internal static class HostBuilderExtensions
{
    /// <summary>
    /// Configures Serilog as a logging providers using the configuration defined in the application settings.
    /// </summary>
    /// <param name="hostBuilder">The host builder.</param>
    internal static void UseSerilogWithConfiguration(this IHostBuilder hostBuilder) =>
        hostBuilder.UseSerilog((hostBuilderContext, loggerConfiguration) =>
            loggerConfiguration.ReadFrom.Configuration(hostBuilderContext.Configuration));
}
