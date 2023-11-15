using Arc.Dependencies.Identity.Interfaces;
using Arc.Facades.Anonymous.Interfaces.Authentication;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.Views.Anonymous.Models;

namespace Arc.Facades.Anonymous.Implementations.Authentication;

public sealed class ForgotPasswordFacade(
    IUserManagerService
        userManagerService,
    IResponsesDomainFacade
        internalFacade,
    IUserNotFoundExceptionDescriptor
        userNotFoundExceptionDescriptor
) : IForgotPasswordFacade
{
    public async Task<Response> Execute(
        ForgotPasswordRequest model
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

        return
            internalFacade
                .CreateOkResponse();
    }
}