using Arc.Infrastructure.Common.Interfaces;

namespace Arc.Models.Views.Common.Models;

public sealed record TableReadRequest(
    IReadOnlyList<FilterPropertyRequestRequest> Filters,
    int CountPerPage,
    int CurrentPage,
    string OrderBy,
    OrderingType OrderingType
) :
    IWithOrderBy,
    IWithOrderingType;