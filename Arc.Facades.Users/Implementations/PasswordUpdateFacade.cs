using Arc.Dependencies.Identity.Interfaces;
using Arc.Facades.Domain.Interface;
using Arc.Facades.Users.Interfaces;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Models.BusinessLogic.Models.Identities;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.Views.Users.Models;

namespace Arc.Facades.Users.Implementations;

public sealed class PasswordUpdateFacade :
    IPasswordUpdateFacade
{
    public async Task<Response> Execute(
        ChangePasswordRequest model,
        UserIdentity identity
    )
    {
        var user =
            await
                _usersReadRepository
                    .GetById(
                        identity.Id
                    );

        await
            _userPasswordManagerService
                .ChangePassword(
                    user!.Email,
                    model.CurrentPassword,
                    model.Password
                );

        return
            _internalFacade
                .CreateOkResponse();
    }

#region Constructor

    private readonly IResponsesDomainFacade
        _internalFacade;

    private readonly IUserPasswordManagerService
        _userPasswordManagerService;

    private readonly IUsersReadRepository
        _usersReadRepository;

    public PasswordUpdateFacade(
        IUsersReadRepository
            usersReadRepository,
        IResponsesDomainFacade
            internalFacade,
        IUserPasswordManagerService
            userPasswordManagerService
    )
    {
        _usersReadRepository =
            usersReadRepository;

        _internalFacade =
            internalFacade;

        _userPasswordManagerService =
            userPasswordManagerService;
    }

#endregion
}