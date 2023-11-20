using Arc.Converters.Views.Common.Interfaces;
using Arc.Dependencies.ConfigurationSettings.Interfaces;
using Arc.Dependencies.RedisStack.Interfaces;
using Arc.Facades.Admins.Interfaces.Admins;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Models.BusinessLogic.Models.Identities;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.Views.Common.Models;

namespace Arc.Facades.Admins.Implementations.Admins;

public sealed class AdminItemListReadFacade(
    IAdminToListItemResponseConverter
        adminToListItemResponseConverter,
    IAdminsReadRepository
        adminsReadRepository,
    IResponsesDomainFacade
        internalFacade,
    IInMemoryDatabaseConnector
        inMemoryDatabaseConnector,
    IRedisStackSettingsFactory
        redisStackSettingsFactory,
    IJsonCommandsService
        jsonCommandsService
) : IAdminItemListReadFacade
{
    public async Task<Response> Execute(
        AdminIdentity identity
    )
    {
        var redisStackSettings =
            redisStackSettingsFactory
                .GetSettings();

        var inMemoryDatabase =
            inMemoryDatabaseConnector
                .GetDatabase(
                    redisStackSettings
                );

        const string AdminListIndex =
            "idx:adminList";

        var resultContainer =
            jsonCommandsService
                .Get<IReadOnlyList<ListItemResponse>>(
                    inMemoryDatabase,
                    AdminListIndex
                );

        IReadOnlyList<ListItemResponse>? responses;

        if (resultContainer.IsSuccess)
        {
            responses =
                resultContainer.Value;
        }
        else
        {
            var admins =
                await
                    adminsReadRepository
                        .GetAll();

            var listItemResponses =
                adminToListItemResponseConverter
                    .Convert(
                        admins
                    );

            jsonCommandsService
                .Set(
                    inMemoryDatabase,
                    AdminListIndex,
                    listItemResponses
                );

            responses =
                listItemResponses.ToList();
        }

        return
            internalFacade
                .CreateOkResponse(
                    responses
                );
    }
}