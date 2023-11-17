using Arc.Controllers.Base.Attributes;
using Arc.Infrastructure.Common.Models;
using Arc.Models.BusinessLogic.Response;

using Microsoft.AspNetCore.Http;

namespace Arc.Controllers.Base.Implementations;

[ApiController]
[DefaultApiRoute]
public abstract class BaseArcController(
    object
        executionFacade
) :
    ControllerBase
{
    protected readonly object
        facade = executionFacade;

    protected static ResultContainer<TItem> GetItem<TItem>(
        HttpContext httpContext,
        string key
    )
        where TItem : class
    {
        var isSuccess =
            httpContext
                .Items
                .TryGetValue(
                    key,
                    out var httpContextItem
                );

        if (!isSuccess)
        {
            return
                ResultContainer<TItem>.Failed();
        }

        var value =
            (httpContextItem as TItem)!;

        return
            ResultContainer<TItem>
                .Successful(
                    value
                );
    }

    protected static OkObjectResult CreateResponse(
        Response responseDto
    ) =>
        new(
            responseDto
        );
}