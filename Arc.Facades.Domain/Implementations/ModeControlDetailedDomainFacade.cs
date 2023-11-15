using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Common.Enums;
using Arc.Infrastructure.Common.Extensions;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Models.BusinessLogic.Models;

namespace Arc.Facades.Domain.Implementations;

public sealed class ModeControlDetailedDomainFacade(
        IAdminsReadRepository
            adminReadRepository,
        IServiceModesReadRepository
            serviceModesReadRepository,
        IUserNotFoundExceptionDescriptor
            userNotFoundExceptionDescriptor
    )
    :
        IModeControlDetailedDomainFacade
{
    public async Task<ServiceModeModel> GetDetailedCurrentMode()
    {
        var currentMode =
            await
                serviceModesReadRepository
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
                adminReadRepository
                    .GetEmailById(
                        currentMode.UpdatedById
                    );

        if (adminEmail.IsEmpty())
        {
            throw
                userNotFoundExceptionDescriptor.CreateException();
        }

        return
            new(
                currentMode.Mode,
                currentMode.UpdateDateTime,
                currentMode.UpdatedById,
                adminEmail
            );
    }
}