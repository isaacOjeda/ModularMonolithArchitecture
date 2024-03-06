using System.Reflection;

namespace Modular.eShop.Catalogs.Endpoints;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
