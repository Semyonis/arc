using Arc.Facades.Authorized.Interfaces;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.Views.Common.Models;

namespace Arc.Facades.Authorized.Implementations;

public sealed class ActorTypeFacade :
    IActorTypeFacade
{
    public async Task<Response> Execute(
        string email
    )
    {
        var admin =
            await
                _actorsReadRepository
                    .GetByEmail(
                        email
                    );

        var actor =
            new ActorTypeResponse(
                admin!.Id,
                admin.Discriminator
            );

        return
            _internalFacade
                .CreateOkResponse(
                    actor
                );
    }

#region Constructor

    private readonly IActorsReadRepository
        _actorsReadRepository;

    private readonly IResponsesDomainFacade
        _internalFacade;

    public ActorTypeFacade(
        IActorsReadRepository
            actorsReadRepository,
        IResponsesDomainFacade
            internalFacade
    )
    {
        _actorsReadRepository =
            actorsReadRepository;

        _internalFacade =
            internalFacade;
    }

#endregion
}