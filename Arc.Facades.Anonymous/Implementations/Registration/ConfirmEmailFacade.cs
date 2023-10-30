using Arc.Dependencies.Identity.Interfaces;
using Arc.Facades.Anonymous.Interfaces.Registration;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Common.Extensions;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.Views.Anonymous.Models;

namespace Arc.Facades.Anonymous.Implementations.Registration;

public sealed class ConfirmEmailFacade :
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
                _badDataExceptionDescriptor.CreateException();
        }

        await
            _userManagerService
                .ConfirmEmail(
                    userId,
                    code
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

    private readonly IBadDataExceptionDescriptor
        _badDataExceptionDescriptor;

    public ConfirmEmailFacade(
        IUserManagerService
            userManagerService,
        IResponsesDomainFacade
            internalFacade,
        IBadDataExceptionDescriptor
            badDataExceptionDescriptor
    )
    {
        _userManagerService =
            userManagerService;

        _internalFacade =
            internalFacade;

        _badDataExceptionDescriptor =
            badDataExceptionDescriptor;
    }

#endregion
}