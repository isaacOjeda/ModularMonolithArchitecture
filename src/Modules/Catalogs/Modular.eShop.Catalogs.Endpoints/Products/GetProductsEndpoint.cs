using FastEndpoints;
using MediatR;
using Modular.eShop.Catalogs.Application.Features.Products.Queries;

namespace Modular.eShop.Catalogs.Endpoints.Products;

internal class GetProductsEndpoint : EndpointWithoutRequest<List<GetProductsQueryResponse>>
{
    private readonly ISender _sender;

    public GetProductsEndpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("/api/products");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var result = await _sender.Send(new GetProductsQuery(), ct);

        await SendAsync(result.Value, cancellation: ct);
    }
}
