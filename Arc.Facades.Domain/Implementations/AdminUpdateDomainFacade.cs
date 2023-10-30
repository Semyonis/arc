using Arc.Facades.Domain.Args;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Repositories.Interfaces;
using Arc.Infrastructure.Repositories.Read.Interfaces;

namespace Arc.Facades.Domain.Implementations;

public sealed class AdminUpdateDomainFacade :
    IAdminUpdateDomainFacade
{
    public async Task Update(
        AdminUpdateDomainFacadeArgs args
    )
    {
        var adminDb =
            await
                _adminsReadRepository
                    .GetById(
                        args.Id
                    );

        adminDb!.FirstName =
            args.FirstName;

        adminDb.LastName =
            args.LastName;

        await
            _adminsRepository
                .UpdateAsync(
                    adminDb
                );
    }

#region Constructor

    private readonly IAdminsReadRepository
        _adminsReadRepository;

    private readonly IUpdateRepository
        _adminsRepository;

    public AdminUpdateDomainFacade(
        IAdminsReadRepository
            adminsReadRepository,
        IUpdateRepository
            adminsRepository
    )
    {
        _adminsReadRepository =
            adminsReadRepository;

        _adminsRepository =
            adminsRepository;
    }

#endregion
}