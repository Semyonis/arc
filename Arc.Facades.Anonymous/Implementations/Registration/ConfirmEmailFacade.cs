using Arc.Dependencies.Identity.Interfaces;
using Arc.Facades.Anonymous.Interfaces.Registration;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Common.Extensions;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.Views.Anonymous.Models;

namespace Arc.Facades.Anonymous.Implementations.Registration;

public sealed class ConfirmEmailFacade(
        IUserManagerService
            userManagerService,
        IResponsesDomainFacade
            internalFacade,
        IBadDataExceptionDescriptor
            badDataExceptionDescriptor
    )
    :
        IConfirmEmailFacade
{
    public async Task<Response> Execute(
        ConfirmEmailRequest confirmEmailRequest
    )
    {
        (
            var userId,
            var code
        ) = confirmEmailRequest;

        var isEmptyId =
            userId.IsEmpty();

        var isEmptyCode =
            code.IsEmpty();

        var isEmpty =
            isEmptyId
            || isEmptyCode;

        if (isEmpty)
        {
            throw
                badDataExceptionDescriptor.CreateException();
        }

        await
            userManagerService
                .ConfirmEmail(
                    userId,
                    code
                );

        return
            internalFacade
                .CreateOkResponse();
    }
}