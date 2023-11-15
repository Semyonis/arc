using Arc.Converters.Views.Users.Interfaces;
using Arc.Facades.Domain.Interface;
using Arc.Facades.Users.Interfaces;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Models.BusinessLogic.Models.Identities;
using Arc.Models.BusinessLogic.Response;

namespace Arc.Facades.Users.Implementations;

public sealed class CurrentFacade(
        IResponsesDomainFacade
            internalFacade,
        IUsersReadRepository
            usersReadRepository,
        IUserToUserResponseConverter
            userToUserResponseConverter
    )
    :
        ICurrentFacade
{
    public async Task<Response> Execute(
        UserIdentity identity
    )
    {
        var user =
            await
                usersReadRepository
                    .GetById(
                        identity.Id
                    );

        var response =
            userToUserResponseConverter
                .Convert(
                    user!
                );

        return
            internalFacade
                .CreateOkResponse(
                    response
                );
    }
}