using FluentResults;

namespace Modular.eShop.Shared.Errors;

public class NotFoundError : Error
{
    public NotFoundError()
        : base("The Entity was not found.")
    {
    }

    public NotFoundError(string entityName)
        : base($"The Entity {entityName} was not found.")
    {
        Metadata.Add("StatusCode", 404);
    }

    public static NotFoundError Create(string entityName) =>
        new(entityName);
}
