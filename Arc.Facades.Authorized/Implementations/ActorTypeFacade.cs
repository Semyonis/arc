using Arc.Facades.Authorized.Interfaces;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.Views.Common.Models;

namespace Arc.Facades.Authorized.Implementations;

public sealed class ActorTypeFacade(
    IActorsReadRepository
        actorsReadRepository,
    IResponsesDomainFacade
        internalFacade
) : IActorTypeFacade
{
    public async Task<Response> Execute(
        string email
    )
    {
        var admin =
            await
                actorsReadRepository
                    .GetByEmail(
                        email
                    );

        var actor =
            new ActorTypeResponse(
                admin!.Id,
                admin.Discriminator
            );

        return
            internalFacade
                .CreateOkResponse(
                    actor
                );
    }
}