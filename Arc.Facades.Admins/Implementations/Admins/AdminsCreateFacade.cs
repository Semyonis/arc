using Arc.Dependencies.RedisStack.Interfaces;
using Arc.Facades.Admins.Interfaces.Admins;
using Arc.Facades.Domain.Args;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Common.Constants;
using Arc.Infrastructure.ConfigurationSettings.Interfaces;
using Arc.Infrastructure.Transactions.Interfaces;
using Arc.Models.BusinessLogic.Models;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.Views.Admins.Models;

namespace Arc.Facades.Admins.Implementations.Admins;

public sealed class AdminsCreateFacade(
    IResponsesDomainFacade
        internalFacade,
    IAdminCreateDomainFacade
        adminCreateDomainFacade,
    ITransactionManager
        transactionManager,
    IInMemoryDatabaseConnector
        inMemoryDatabaseConnector,
    IRedisStackSettingsFactory
        redisStackSettingsFactory,
    IJsonCommandsService
        jsonCommandsService
) : IAdminsCreateFacade
{
    public async Task<Response> Execute(
        AdminCreateRequest request,
        ArcIdentity identity
    )
    {
        using var transaction =
            await
                transactionManager
                    .BeginTransaction();

        var admin =
            new AdminCreateDomainFacadeArgs(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password
            );

        var adminId =
            await
                adminCreateDomainFacade
                    .Create(
                        admin
                    );

        await
            transaction
                .Commit();

        var redisStackSettings =
            redisStackSettingsFactory
                .GetSettings();

        var inMemoryDatabase =
            inMemoryDatabaseConnector
                .GetDatabase(
                    redisStackSettings
                );

        await
            jsonCommandsService
                .Delete(
                    inMemoryDatabase,
                    RedisKeyConstants.AdminListKey
                );

        return
            internalFacade
                .CreateOkResponse(
                    adminId
                );
    }
}