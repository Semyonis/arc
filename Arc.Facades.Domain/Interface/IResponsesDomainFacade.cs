using Arc.Models.BusinessLogic.Response;

namespace Arc.Facades.Domain.Interface;

public interface IResponsesDomainFacade
{
    Response CreateOkResponse(
        object? data = default
    );
}