using Arc.Dependencies.Identity.Interfaces;
using Arc.Facades.Anonymous.Interfaces.Authentication;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.Views.Anonymous.Models;

namespace Arc.Facades.Anonymous.Implementations.Authentication;

public sealed class ResetPasswordFacade(
        IUserManagerService
            userManagerService,
        IResponsesDomainFacade
            internalFacade,
        IUserPasswordManagerService
            userPasswordManagerService,
        IUserNotFoundExceptionDescriptor
            userNotFoundExceptionDescriptor
    )
    :
        IResetPasswordFacade
{
    public async Task<Response> Execute(
        ResetPasswordRequest model
    )
    {
        var user =
            await
                userManagerService
                    .FindByEmail(
                        model.Email
                    );

        if (user == default)
        {
            throw
                userNotFoundExceptionDescriptor
                    .CreateException(
                        model.Email
                    );
        }

        await
            userPasswordManagerService
                .ResetPassword(
                    user,
                    model.Code,
                    model.Password
                );

        return
            internalFacade
                .CreateOkResponse();
    }
}