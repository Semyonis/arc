using Arc.Dependencies.Identity.Interfaces;
using Arc.Facades.Domain.Interface;
using Arc.Facades.Users.Interfaces;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Models.BusinessLogic.Models.Identities;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.Views.Users.Models;

namespace Arc.Facades.Users.Implementations;

public sealed class PasswordUpdateFacade(
        IUsersReadRepository
            usersReadRepository,
        IResponsesDomainFacade
            internalFacade,
        IUserPasswordManagerService
            userPasswordManagerService
    )
    :
        IPasswordUpdateFacade
{
    public async Task<Response> Execute(
        ChangePasswordRequest model,
        UserIdentity identity
    )
    {
        var user =
            await
                usersReadRepository
                    .GetById(
                        identity.Id
                    );

        await
            userPasswordManagerService
                .ChangePassword(
                    user!.Email,
                    model.CurrentPassword,
                    model.Password
                );

        return
            internalFacade
                .CreateOkResponse();
    }
}