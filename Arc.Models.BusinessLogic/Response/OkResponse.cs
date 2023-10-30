namespace Arc.Models.BusinessLogic.Response;

public sealed record OkResponse(
    object? Data,
    PaginationResponse? Pagination
) : Response;