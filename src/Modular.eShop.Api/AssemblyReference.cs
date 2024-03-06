using System.Reflection;

namespace Modular.eShop.Api;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
