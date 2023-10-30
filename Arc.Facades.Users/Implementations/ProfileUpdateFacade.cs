using Arc.Facades.Domain.Interface;
using Arc.Facades.Users.Interfaces;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Infrastructure.Transactions.Interfaces;
using Arc.Models.BusinessLogic.Models.Identities;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.Views.Users.Models;

namespace Arc.Facades.Users.Implementations;

public sealed class ProfileUpdateFacade :
    IProfileUpdateFacade
{
    public async Task<Response> Execute(
        UserRequest userProfile,
        UserIdentity identity
    )
    {
        if (userProfile.Id != identity.Id)
        {
            throw
                _accessDeniedExceptionDescriptor.CreateException();
        }

        using var transaction =
            await
                _transactionManager.BeginTransaction();

        var user =
            await
                _usersReadRepository
                    .GetById(
                        userProfile.Id,
                        asNoTracking: false
                    );

        if (user == default)
        {
            throw
                _userNotFoundExceptionDescriptor.CreateException();
        }

        user.FirstName =
            userProfile.FirstName;

        user.LastName =
            userProfile.LastName;

        await
            transaction
                .Commit();

        return
            _internalFacade
                .CreateOkResponse();
    }

#region Constructor

    private readonly IResponsesDomainFacade
        _internalFacade;

    private readonly ITransactionManager
        _transactionManager;

    private readonly IUsersReadRepository
        _usersReadRepository;

    private readonly IUserNotFoundExceptionDescriptor
        _userNotFoundExceptionDescriptor;

    private readonly IAccessDeniedExceptionDescriptor
        _accessDeniedExceptionDescriptor;

    public ProfileUpdateFacade(
        IResponsesDomainFacade
            internalFacade,
        IUsersReadRepository
            usersReadRepository,
        ITransactionManager
            transactionManager,
        IUserNotFoundExceptionDescriptor
            userNotFoundExceptionDescriptor,
        IAccessDeniedExceptionDescriptor
            accessDeniedExceptionDescriptor
    )
    {
        _internalFacade =
            internalFacade;

        _usersReadRepository =
            usersReadRepository;

        _transactionManager =
            transactionManager;

        _userNotFoundExceptionDescriptor =
            userNotFoundExceptionDescriptor;

        _accessDeniedExceptionDescriptor =
            accessDeniedExceptionDescriptor;
    }

#endregion
}