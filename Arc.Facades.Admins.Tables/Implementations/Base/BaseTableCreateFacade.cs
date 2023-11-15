using Arc.Converters.Base.Interfaces;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Common.Interfaces;
using Arc.Infrastructure.Repositories.Interfaces;
using Arc.Infrastructure.Transactions.Interfaces;
using Arc.Models.BusinessLogic.Models.Identities;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.Views.Admins.Models;

namespace Arc.Facades.Admins.Tables.Implementations.Base;

public abstract class BaseTableCreateFacade
<
    TEntity,
    TCreateEntityRequest
>(
    ICreateRepository
        repository,
    IResponsesDomainFacade
        internalFacade,
    IConverterBase<TCreateEntityRequest, TEntity>
        createConverter,
    ITransactionManager
        transactionManager
)
    where TEntity : class, IWithIdentifier
{
    protected async Task<Response> Execute(
        IReadOnlyList<TCreateEntityRequest> newEntities,
        AdminIdentity identity
    )
    {
        await
            ValidateOnCreate(
                newEntities,
                identity
            );

        var entityList =
            createConverter
                .Convert(
                    newEntities
                );

        using var transaction =
            await
                transactionManager
                    .BeginTransaction();

        var createdCount =
            await
                repository
                    .CreateCollectionAsync(
                        entityList
                    );

        var changedEntityIds =
            entityList
                .Select(
                    item =>
                        item.Id
                )
                .ToList();

        var result =
            new TableActionResultResponse(
                createdCount,
                changedEntityIds
            );

        await
            transaction
                .Commit();

        return
            internalFacade
                .CreateOkResponse(
                    result
                );
    }

    protected virtual Task ValidateOnCreate(
        IReadOnlyList<TCreateEntityRequest> createEntities,
        AdminIdentity identity
    ) =>
        Task.CompletedTask;
}