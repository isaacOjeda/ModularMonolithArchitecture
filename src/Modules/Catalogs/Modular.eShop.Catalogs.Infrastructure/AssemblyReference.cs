using System.Reflection;

namespace Modular.eShop.Catalogs.Infrastructure;

/// <summary>
/// Represents the training module endpoints assembly reference.
/// </summary>
public static class AssemblyReference
{
    /// <summary>
    /// The assembly.
    /// </summary>
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
