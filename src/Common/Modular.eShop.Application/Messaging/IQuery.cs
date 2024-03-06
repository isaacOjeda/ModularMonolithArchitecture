using FluentResults;
using MediatR;

namespace Modular.eShop.Application.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
