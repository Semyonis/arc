using Arc.Models.BusinessLogic.Response;

namespace Arc.Facades.Domain.Args;

public sealed record PageResponsesDomainFacadeArgs<TEntity>(
    IReadOnlyList<TEntity> Data,
    PaginationOut PaginationOut
);