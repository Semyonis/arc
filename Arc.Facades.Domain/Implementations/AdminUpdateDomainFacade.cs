using Arc.Facades.Domain.Args;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Repositories.Interfaces;
using Arc.Infrastructure.Repositories.Read.Interfaces;

namespace Arc.Facades.Domain.Implementations;

public sealed class AdminUpdateDomainFacade(
        IAdminsReadRepository
            adminsReadRepository,
        IUpdateRepository
            adminsRepository
    )
    :
        IAdminUpdateDomainFacade
{
    public async Task Update(
        AdminUpdateDomainFacadeArgs args
    )
    {
        var adminDb =
            await
                adminsReadRepository
                    .GetById(
                        args.Id
                    );

        adminDb!.FirstName =
            args.FirstName;

        adminDb.LastName =
            args.LastName;

        await
            adminsRepository
                .UpdateAsync(
                    adminDb
                );
    }
}