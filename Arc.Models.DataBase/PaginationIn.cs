namespace Arc.Models.DataBase;

public sealed record PaginationIn(
    int CurrentPage,
    int CountPerPage
)
{
    public static PaginationIn GetPagination(
        int currentPage,
        int countPerPage,
        int defaultPageSize = 10
    )
    {
        var isIncorrect =
            currentPage < 1
            || countPerPage < 1;

        if (isIncorrect)
        {
            return
                GetFirstPage(
                    defaultPageSize
                );
        }

        return new(
            currentPage,
            countPerPage
        );
    }

    public static PaginationIn GetFirstPage(
        int countPerPage
    ) =>
        new(
            1,
            countPerPage
        );
}