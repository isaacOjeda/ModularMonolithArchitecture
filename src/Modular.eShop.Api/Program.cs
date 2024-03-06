using FastEndpoints;
using Modular.eShop.Api.Extensions;
using Modular.eShop.Infrastructure.Extensions;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

try
{
    Log.Information("Starting up");

    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilogWithConfiguration();

    // Servicios de API y Cross Cutting Concerns
    builder.Services.InstallServicesFromAssemblies(
        builder.Configuration,
        Modular.eShop.Api.AssemblyReference.Assembly);

    // Módulos de la aplicación
    builder.Services.InstallModulesFromAssemblies(
        builder.Configuration,
        Modular.eShop.Catalogs.Infrastructure.AssemblyReference.Assembly);

    WebApplication app = builder.Build();

    app.UseSerilogRequestLogging();
    app.MapGet("/", () => "Hello World!");

    app.UseFastEndpoints();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");

    throw;
}
finally
{
    Log.CloseAndFlush();
}
