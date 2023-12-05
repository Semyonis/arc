using Arc.Database.Entities.Models;
using Arc.Facades.Domain.Args;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Repositories.Interfaces;

namespace Arc.Facades.Domain.Implementations;

public sealed class ModeControlDomainFacade(
    ICreateRepository
        serviceModesRepository
) : IModeControlDomainFacade
{
    public async Task SetMode(
        ModeControlDomainFacadeArgs args
    )
    {
        (
            var serviceModeType,
            var adminId
        ) = args;

        var currentMode =
            new ServiceMode
            {
                UpdatedById = adminId,
                Mode = serviceModeType,
                UpdateDateTime = DateTime.UtcNow,
            };

        await
            serviceModesRepository
                .CreateAsync(
                    currentMode
                );
    }
}