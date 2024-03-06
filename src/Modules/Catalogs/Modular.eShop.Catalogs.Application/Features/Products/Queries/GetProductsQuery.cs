using FluentResults;
using Microsoft.EntityFrameworkCore;
using Modular.eShop.Application.Messaging;
using Modular.eShop.Catalogs.Application.Common.Interfaces;

namespace Modular.eShop.Catalogs.Application.Features.Products.Queries;

public class GetProductsQuery : IQuery<List<GetProductsQueryResponse>>
{
}

public class GetProductsQueryResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public string Description { get; set; } = default!;

    public decimal Price { get; set; }

    public int ProductTypeId { get; set; }

    public string ProductType { get; set; } = default!;

    public int ProductBrandId { get; set; }

    public string ProductBrand { get; set; } = default!;
}

internal class GetProductsQueryHandler(ICatalogDbContext context)
    : IQueryHandler<GetProductsQuery, List<GetProductsQueryResponse>>
{
    private readonly ICatalogDbContext _context = context;

    public async Task<Result<List<GetProductsQueryResponse>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _context.Products
            .Where(q => q.Active)
            .Select(s => new GetProductsQueryResponse
            {
                Id = s.Id.Value,
                Name = s.Name,
                Description = s.Description,
                Price = s.Price,
                ProductTypeId = s.ProductTypeId,
                ProductType = s.ProductType!.Type,
                ProductBrandId = s.ProductBrandId,
                ProductBrand = s.ProductBrand!.Brand,
            })
            .ToListAsync(cancellationToken);

        return Result.Ok(products);
    }
}
