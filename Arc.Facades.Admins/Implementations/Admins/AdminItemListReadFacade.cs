using Arc.Converters.Views.Common.Interfaces;
using Arc.Dependencies.RedisStack.Interfaces;
using Arc.Facades.Admins.Interfaces.Admins;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Common.Constants;
using Arc.Infrastructure.ConfigurationSettings.Interfaces;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Models.BusinessLogic.Models;
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
        ArcIdentity identity
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

        var resultContainer =
            jsonCommandsService
                .Get<IReadOnlyList<ListItemResponse>>(
                    inMemoryDatabase,
                    RedisKeyConstants.AdminListKey
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
                    RedisKeyConstants.AdminListKey,
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