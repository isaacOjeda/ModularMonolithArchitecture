using FluentResults;
using FluentValidation;
using MediatR;
using Modular.eShop.Shared.Errors;

namespace Modular.eShop.Application.Behaviors;

/// <summary>
/// Represents the validation pipeline behavior.
/// </summary>
/// <typeparam name="TRequest">The request type.</typeparam>
/// <typeparam name="TResponse">The response type.</typeparam>
public class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
    where TResponse : ResultBase
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationPipelineBehavior{TRequest,TResponse}"/> class.
    /// </summary>
    /// <param name="validators">The validators for the given request.</param>
    public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

    /// <inheritdoc />
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);

        var validationResults = await Task.WhenAll(
            _validators.Select(v =>
                v.ValidateAsync(context, cancellationToken)));

        var failures = validationResults
            .Where(r => r.Errors.Count != 0)
            .SelectMany(r => r.Errors)
            .ToList();

        if (failures.Count != 0)
        {

            var response = Activator.CreateInstance<TResponse>();

            response.Reasons.Add(new ValidationError(failures));

            return response;
        }

        return await next();
    }
}
