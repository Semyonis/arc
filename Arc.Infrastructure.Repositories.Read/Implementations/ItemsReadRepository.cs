using Arc.Database.Context;
using Arc.Infrastructure.Repositories.Read.Implementations.Base;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Database.Entities.Models;

namespace Arc.Infrastructure.Repositories.Read.Implementations;

public sealed class ItemsReadRepository(
    ArcDatabaseContext context
) :
    IdReadRepositoryBase<Item>(
        context
    ),
    IItemsReadRepository;