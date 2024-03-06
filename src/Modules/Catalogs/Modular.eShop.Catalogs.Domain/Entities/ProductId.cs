using Modular.eShop.Domain.Primitives;

namespace Modular.eShop.Catalogs.Domain.Entities;

public sealed record ProductId(Guid Value) : IEntityId;
