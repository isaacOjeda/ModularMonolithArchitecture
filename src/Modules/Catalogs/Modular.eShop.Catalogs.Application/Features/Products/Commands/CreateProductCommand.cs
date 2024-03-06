using FluentResults;
using FluentValidation;
using Modular.eShop.Application.Messaging;
using Modular.eShop.Catalogs.Application.Common.Interfaces;
using Modular.eShop.Catalogs.Domain.Entities;
using Modular.eShop.Shared.Errors;

namespace Modular.eShop.Catalogs.Application.Features.Products.Commands;

public class CreateProductCommand : ICommand
{
    public string Name { get; set; } = default!;

    public string Description { get; set; } = default!;

    public decimal Price { get; set; }

    public int ProductTypeId { get; set; }

    public int ProductBrandId { get; set; }
}

internal class CreateProductCommandHandler(ICatalogDbContext context) : ICommandHandler<CreateProductCommand>
{
    private readonly ICatalogDbContext _context = context;

    public async Task<Result> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var productBrand = await _context.ProductBrands.FindAsync([request.ProductBrandId], cancellationToken: cancellationToken);
        if (productBrand is null)
        {
            return ValidationError.CreateResult("Product Brand does not exist");
        }

        var productType = await _context.ProductTypes.FindAsync([request.ProductTypeId], cancellationToken: cancellationToken);
        if (productType is null)
        {
            return ValidationError.CreateResult("Product Type does not exist");
        }

        var newProduct = Product.Create(new ProductId(Guid.NewGuid()), request.Name, request.Description, request.Price, request.ProductTypeId, request.ProductBrandId);

        _context.Products.Add(newProduct);

        await _context.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}

internal class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Description).NotEmpty().MaximumLength(500);
        RuleFor(x => x.Price).GreaterThan(0);
        RuleFor(x => x.ProductTypeId).GreaterThan(0);
        RuleFor(x => x.ProductBrandId).GreaterThan(0);
    }
}
