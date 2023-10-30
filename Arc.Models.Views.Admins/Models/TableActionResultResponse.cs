// ReSharper disable NotAccessedPositionalProperty.Global

namespace Arc.Models.Views.Admins.Models;

public sealed record TableActionResultResponse(
    int ChangedEntitiesCount,
    IReadOnlyList<int> ChangedEntityIds
);