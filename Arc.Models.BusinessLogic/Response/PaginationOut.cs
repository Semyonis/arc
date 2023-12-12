namespace Arc.Models.BusinessLogic.Response;

public sealed record PaginationOut
{
    private PaginationOut() { }

    public int CountPerPage { get; private init; }

    public int CurrentPage { get; private init; }

    public int PageCount { get; private init; }

    public int TotalItemsCount { get; private init; }

    public static PaginationOut GetPagination(
        int currentPage,
        int countPerPage,
        int totalItemCount,
        int defaultPageSize = 10
    )
    {
        if (currentPage < 1
            || countPerPage < 1)
        {
            return
                new()
                {
                    CurrentPage = 1,
                    CountPerPage = defaultPageSize,
                    TotalItemsCount = totalItemCount,
                };
        }

        var fullPageCount =
            totalItemCount / countPerPage;

        var hasAdditionalPage =
            totalItemCount % countPerPage > 0;

        var shift =
            hasAdditionalPage
                ? 1
                : 0;

        var pageCount =
            fullPageCount + shift;

        return new()
        {
            CurrentPage = currentPage,
            CountPerPage = countPerPage,
            PageCount = pageCount,
            TotalItemsCount = totalItemCount,
        };
    }
}