using Arc.Facades.Domain.Args;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Repositories.Interfaces;
using Arc.Models.DataBase.Models;

namespace Arc.Facades.Domain.Implementations;

public sealed class ModeControlDomainFacade :
    IModeControlDomainFacade
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
            _serviceModesRepository
                .CreateAsync(
                    currentMode
                );
    }

#region Constructor

    private readonly ICreateRepository
        _serviceModesRepository;

    public ModeControlDomainFacade(
        ICreateRepository
            serviceModesRepository
    ) =>
        _serviceModesRepository =
            serviceModesRepository;

#endregion
}