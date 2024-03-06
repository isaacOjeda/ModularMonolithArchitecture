using System.Reflection;

namespace Modular.eShop.Catalogs.Application;

/// <summary>
/// Represents the training module application assembly reference.
/// </summary>
public static class AssemblyReference
{
    /// <summary>
    /// The assembly.
    /// </summary>
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
