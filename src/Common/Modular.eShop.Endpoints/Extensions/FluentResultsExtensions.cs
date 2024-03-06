using FluentResults;
using Microsoft.AspNetCore.Http;
using Modular.eShop.Shared.Errors;

namespace Modular.eShop.Endpoints.Extensions;
public static class FluentResultsExtensions
{
    public static IResult HandleFailure(this Result result)
    {
        if (result.IsSuccess)
        {
            throw new InvalidOperationException("Result is not a failure.");
        }

        var error = result.Errors.FirstOrDefault();

        return error switch
        {
            ValidationError validationError => TypedResults.ValidationProblem(
                validationError.Failures
                    .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                    .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray())),
            NotFoundError _ => TypedResults.NotFound(),
            _ => TypedResults.Problem(detail: error?.Message ?? "An error has ocurred."),
        };
    }
}
