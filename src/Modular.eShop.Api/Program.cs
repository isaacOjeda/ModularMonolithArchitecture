using FastEndpoints;
using Modular.eShop.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Servicios de API y Cross Cutting Concerns
builder.Services.InstallServicesFromAssemblies(
    builder.Configuration,
    Modular.eShop.Api.AssemblyReference.Assembly);

// Módulos de la aplicación
builder.Services.InstallModulesFromAssemblies(
    builder.Configuration,
    Modular.eShop.Catalogs.Infrastructure.AssemblyReference.Assembly);

WebApplication app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseFastEndpoints();

app.Run();
