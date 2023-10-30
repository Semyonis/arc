using Arc.Facades.Domain.Args;
using Arc.Facades.Domain.Interface;
using Arc.Models.BusinessLogic.Response;

namespace Arc.Facades.Domain.Implementations;

public sealed class PageResponsesDomainFacade :
    IPageResponsesDomainFacade
{
    public Response CreatePageResponse<TEntity>(
        PageResponsesDomainFacadeArgs<TEntity> args
    )
    {
        (
            var data,
            var pagination
        ) = args;

        var paginationResponse =
            new PaginationResponse(
                pagination.CountPerPage,
                pagination.CurrentPage,
                pagination.PageCount,
                pagination.TotalItemsCount
            );

        return
            new OkResponse(
                data,
                paginationResponse
            );
    }
}