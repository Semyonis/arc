using Arc.Facades.Domain.Args;
using Arc.Models.BusinessLogic.Response;

namespace Arc.Facades.Domain.Interface;

public interface IPageResponsesDomainFacade
{
    Response CreatePageResponse<TEntity>(
        PageResponsesDomainFacadeArgs<TEntity> args
    );
}