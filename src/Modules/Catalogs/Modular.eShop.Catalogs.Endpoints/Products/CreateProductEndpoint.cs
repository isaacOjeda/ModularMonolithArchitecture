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

        Description(d => d
            .ProducesValidationProblem()
            .Produces(StatusCodes.Status404NotFound));

        Summary(s =>
        {
            s.Summary = "Create a product.";
            s.Description = "Create a product.";
            s.ExampleRequest = new CreateProductCommand
            {
                Name = "Product Name",
                Description = "Product Description",
                Price = 100.00m,
            };
            s.Responses[StatusCodes.Status200OK] = "Product created.";
        });
    }

    public override async Task HandleAsync(CreateProductCommand request, CancellationToken ct)
    {
        var result = await _sender.Send(request, ct);

        await SendResultAsync(!result.IsSuccess ? result.HandleFailure() : TypedResults.Ok());
    }
}
