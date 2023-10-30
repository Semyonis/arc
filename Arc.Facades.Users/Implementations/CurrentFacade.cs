using Arc.Converters.Views.Users.Interfaces;
using Arc.Facades.Domain.Interface;
using Arc.Facades.Users.Interfaces;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Models.BusinessLogic.Models.Identities;
using Arc.Models.BusinessLogic.Response;

namespace Arc.Facades.Users.Implementations;

public sealed class CurrentFacade :
    ICurrentFacade
{
    public async Task<Response> Execute(
        UserIdentity identity
    )
    {
        var user =
            await
                _usersReadRepository
                    .GetById(
                        identity.Id
                    );

        var response =
            _userToUserResponseConverter
                .Convert(
                    user!
                );

        return
            _internalFacade
                .CreateOkResponse(
                    response
                );
    }

#region Constructor

    private readonly IResponsesDomainFacade
        _internalFacade;

    private readonly IUsersReadRepository
        _usersReadRepository;

    private readonly IUserToUserResponseConverter
        _userToUserResponseConverter;

    public CurrentFacade(
        IResponsesDomainFacade
            internalFacade,
        IUsersReadRepository
            usersReadRepository,
        IUserToUserResponseConverter
            userToUserResponseConverter
    )
    {
        _internalFacade =
            internalFacade;

        _usersReadRepository =
            usersReadRepository;

        _userToUserResponseConverter =
            userToUserResponseConverter;
    }

#endregion
}