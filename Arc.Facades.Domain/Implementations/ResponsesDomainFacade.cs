using Arc.Facades.Domain.Interface;
using Arc.Models.BusinessLogic.Response;

namespace Arc.Facades.Domain.Implementations;

public sealed class ResponsesDomainFacade :
    IResponsesDomainFacade
{
    public Response CreateOkResponse(
        object? data = default
    ) =>
        new OkResponse(
            data,
            default
        );
}