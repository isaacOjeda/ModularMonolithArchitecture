using FluentResults;
using MediatR;

namespace Modular.eShop.Application.Messaging;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}
