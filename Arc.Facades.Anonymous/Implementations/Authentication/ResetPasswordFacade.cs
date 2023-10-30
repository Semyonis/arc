using Arc.Dependencies.Identity.Interfaces;
using Arc.Facades.Anonymous.Interfaces.Authentication;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.Views.Anonymous.Models;

namespace Arc.Facades.Anonymous.Implementations.Authentication;

public sealed class ResetPasswordFacade :
    IResetPasswordFacade
{
    public async Task<Response> Execute(
        ResetPasswordRequest model
    )
    {
        var user =
            await
                _userManagerService
                    .FindByEmail(
                        model.Email
                    );

        if (user == default)
        {
            throw
                _userNotFoundExceptionDescriptor
                    .CreateException(
                        model.Email
                    );
        }

        await
            _userPasswordManagerService
                .ResetPassword(
                    user,
                    model.Code,
                    model.Password
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

    private readonly IUserPasswordManagerService
        _userPasswordManagerService;

    private readonly IUserNotFoundExceptionDescriptor
        _userNotFoundExceptionDescriptor;

    public ResetPasswordFacade(
        IUserManagerService
            userManagerService,
        IResponsesDomainFacade
            internalFacade,
        IUserPasswordManagerService
            userPasswordManagerService,
        IUserNotFoundExceptionDescriptor
            userNotFoundExceptionDescriptor
    )
    {
        _userManagerService =
            userManagerService;

        _internalFacade =
            internalFacade;

        _userPasswordManagerService =
            userPasswordManagerService;

        _userNotFoundExceptionDescriptor =
            userNotFoundExceptionDescriptor;
    }

#endregion
}