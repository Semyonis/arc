using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Common.Enums;
using Arc.Infrastructure.Common.Extensions;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Models.BusinessLogic.Models;

namespace Arc.Facades.Domain.Implementations;

public sealed class ModeControlDetailedDomainFacade :
    IModeControlDetailedDomainFacade
{
    public async Task<ServiceModeModel> GetDetailedCurrentMode()
    {
        var currentMode =
            await
                _serviceModesReadRepository
                    .GetCurrent();

        if (currentMode == default)
        {
            return
                new(
                    ServiceModeType.On,
                    DateTime.MinValue,
                    0,
                    ""
                );
        }

        var adminEmail =
            await
                _adminReadRepository
                    .GetEmailById(
                        currentMode.UpdatedById
                    );

        if (adminEmail.IsEmpty())
        {
            throw
                _userNotFoundExceptionDescriptor.CreateException();
        }

        return
            new(
                currentMode.Mode,
                currentMode.UpdateDateTime,
                currentMode.UpdatedById,
                adminEmail
            );
    }

#region Constructor

    private readonly IAdminsReadRepository
        _adminReadRepository;

    private readonly IServiceModesReadRepository
        _serviceModesReadRepository;

    private readonly IUserNotFoundExceptionDescriptor
        _userNotFoundExceptionDescriptor;

    public ModeControlDetailedDomainFacade(
        IAdminsReadRepository
            adminReadRepository,
        IServiceModesReadRepository
            serviceModesReadRepository,
        IUserNotFoundExceptionDescriptor
            userNotFoundExceptionDescriptor
    )
    {
        _adminReadRepository =
            adminReadRepository;

        _serviceModesReadRepository =
            serviceModesReadRepository;

        _userNotFoundExceptionDescriptor =
            userNotFoundExceptionDescriptor;
    }

#endregion
}