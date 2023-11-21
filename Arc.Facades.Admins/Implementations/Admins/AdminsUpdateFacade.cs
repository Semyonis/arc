using Arc.Dependencies.RedisStack.Interfaces;
using Arc.Facades.Admins.Interfaces.Admins;
using Arc.Facades.Domain.Args;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Common.Constants;
using Arc.Infrastructure.ConfigurationSettings.Interfaces;
using Arc.Infrastructure.Transactions.Interfaces;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.Views.Admins.Models;

namespace Arc.Facades.Admins.Implementations.Admins;

public sealed class AdminsUpdateFacade(
    IResponsesDomainFacade
        internalFacade,
    ITransactionManager
        transactionManager,
    IAdminUpdateDomainFacade
        adminUpdateDomainFacade,
    IInMemoryDatabaseConnector
        inMemoryDatabaseConnector,
    IRedisStackSettingsFactory
        redisStackSettingsFactory,
    IJsonCommandsService
        jsonCommandsService
) : IAdminsUpdateFacade
{
    public async Task<Response> Execute(
        AdminUpdateRequest request
    )
    {
        using var transaction =
            await
                transactionManager
                    .BeginTransaction();

        var admin =
            new AdminUpdateDomainFacadeArgs(
                request.Id,
                request.FirstName,
                request.LastName
            );

        await
            adminUpdateDomainFacade
                .Update(
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
                .CreateOkResponse();
    }
}