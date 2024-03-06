using FluentResults;
using MediatR;

namespace Modular.eShop.Application.Messaging;


public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}
