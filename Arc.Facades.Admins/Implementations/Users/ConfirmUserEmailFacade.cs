using Arc.Dependencies.Identity.Interfaces;
using Arc.Facades.Admins.Interfaces.Users;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Common.Extensions;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Models.BusinessLogic.Models.Identities;
using Arc.Models.BusinessLogic.Response;

namespace Arc.Facades.Admins.Implementations.Users;

public sealed class ConfirmUserEmailFacade :
    IConfirmUserEmailFacade
{
    public async Task<Response> Execute(
        int userId,
        AdminIdentity identity
    )
    {
        var userEmail =
            await
                _usersReadRepository
                    .GetEmailById(
                        userId
                    );

        if (userEmail.IsEmpty())
        {
            throw
                _userNotFoundExceptionDescriptor.CreateException();
        }

        var user =
            await
                _userManagerService
                    .FindByEmail(
                        userEmail
                    );

        if (user == default)
        {
            throw
                _userNotFoundExceptionDescriptor.CreateException();
        }

        var token =
            await
                _userTokenManagerService
                    .GetEmailChangeToken(
                        user,
                        userEmail
                    );

        var oldEmail =
            user.Email!;

        await
            _userManagerService
                .ConfirmNewEmail(
                    token,
                    oldEmail,
                    oldEmail
                );

        return
            _internalFacade
                .CreateOkResponse();
    }

#region Constructor

    private readonly IResponsesDomainFacade
        _internalFacade;

    private readonly IUserManagerService
        _userManagerService;

    private readonly IUserTokenManagerService
        _userTokenManagerService;

    private readonly IUsersReadRepository
        _usersReadRepository;

    private readonly IUserNotFoundExceptionDescriptor
        _userNotFoundExceptionDescriptor;

    public ConfirmUserEmailFacade(
        IUserManagerService
            userManagerService,
        IResponsesDomainFacade
            internalFacade,
        IUserTokenManagerService
            userTokenManagerService,
        IUsersReadRepository
            usersReadRepository,
        IUserNotFoundExceptionDescriptor
            userNotFoundExceptionDescriptor
    )
    {
        _userManagerService =
            userManagerService;

        _internalFacade =
            internalFacade;

        _userTokenManagerService =
            userTokenManagerService;

        _usersReadRepository =
            usersReadRepository;

        _userNotFoundExceptionDescriptor =
            userNotFoundExceptionDescriptor;
    }

#endregion
}