using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Http;
using Modular.eShop.Catalogs.Application.Features.Products.Commands;
using Modular.eShop.Endpoints.Extensions;

namespace Modular.eShop.Catalogs.Endpoints.Products;
internal class CreateProductEndpoint : Endpoint<CreateProductCommand>
{
    private readonly ISender _sender;

    public CreateProductEndpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("/api/products");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateProductCommand request, CancellationToken ct)
    {
        var result = await _sender.Send(request, ct);

        await SendResultAsync(!result.IsSuccess ? result.HandleFailure() : TypedResults.Ok());
    }
}
