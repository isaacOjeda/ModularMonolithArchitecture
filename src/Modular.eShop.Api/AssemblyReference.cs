using System.Reflection;

namespace Modular.eShop.Api;

/// <summary>
/// Assembly Reference Class.
/// </summary>
public static class AssemblyReference
{
    /// <summary>
    /// Assembly access.
    /// </summary>
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
