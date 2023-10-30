namespace Arc.Models.BusinessLogic.Response;

public sealed record PaginationResponse(
    int CountPerPage,
    int CurrentPage,
    int PageCount,
    int TotalItemsCount
);