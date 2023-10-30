using Arc.Dependencies.Identity.Interfaces;
using Arc.Facades.Anonymous.Interfaces.Authentication;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.Views.Anonymous.Models;

namespace Arc.Facades.Anonymous.Implementations.Authentication;

public sealed class ForgotPasswordFacade :
    IForgotPasswordFacade
{
    public async Task<Response> Execute(
        ForgotPasswordRequest model
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

        return
            _internalFacade
                .CreateOkResponse();
    }

#region Constructor

    private readonly IResponsesDomainFacade
        _internalFacade;

    private readonly IUserManagerService
        _userManagerService;

    private readonly IUserNotFoundExceptionDescriptor
        _userNotFoundExceptionDescriptor;

    public ForgotPasswordFacade(
        IUserManagerService
            userManagerService,
        IResponsesDomainFacade
            internalFacade,
        IUserNotFoundExceptionDescriptor
            userNotFoundExceptionDescriptor
    )
    {
        _userManagerService =
            userManagerService;

        _internalFacade =
            internalFacade;

        _userNotFoundExceptionDescriptor =
            userNotFoundExceptionDescriptor;
    }

#endregion
}