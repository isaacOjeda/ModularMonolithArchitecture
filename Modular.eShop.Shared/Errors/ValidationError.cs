using FluentResults;
using FluentValidation.Results;

namespace Modular.eShop.Shared.Errors;

public class ValidationError : Error
{
    public ValidationError(List<ValidationFailure> failures)
    {
        Failures = failures;
    }

    public List<ValidationFailure> Failures { get; }

    public static Result CreateResult(string validationError)
    {
        var failures = new List<ValidationFailure>
        {
            new ValidationFailure(string.Empty, validationError)
        };

        return Result.Fail(new ValidationError(failures));
    }
}
