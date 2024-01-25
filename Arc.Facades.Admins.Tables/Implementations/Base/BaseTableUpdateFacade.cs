using Arc.Converters.Base.Interfaces;
using Arc.Criteria.Implementations;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Common.Extensions;
using Arc.Infrastructure.Common.Interfaces;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Infrastructure.Repositories.Interfaces;
using Arc.Infrastructure.Transactions.Interfaces;
using Arc.Models.BusinessLogic.Models;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.Views.Admins.Models;

using Microsoft.EntityFrameworkCore.Query;

namespace Arc.Facades.Admins.Tables.Implementations.Base;

public abstract class BaseTableUpdateFacade
<
    TEntity,
    TUpdateEntityRequest
>(
    IUpdateRepository
        repository,
    IResponsesDomainFacade
        internalFacade,
    IConverterBase<TUpdateEntityRequest, TEntity>
        updateConverter,
    ITransactionManager
        transactionManager,
    IBadDataExceptionDescriptor
        badDataExceptionDescriptor
)
    where TEntity : class, IWithIdentifier
    where TUpdateEntityRequest : IWithIdentifier
{
    protected async Task<Response> Execute(
        IReadOnlyList<TUpdateEntityRequest> updateEntities,
        ArcIdentity identity
    )
    {
        await
            ValidateOnUpdate(
                updateEntities,
                identity
            );

        var entityIds =
            updateEntities
                .Select(
                    request =>
                        request.Id
                )
                .ToList();

        var criteria =
            new ReadRepositoryEntityIdsCriteria<TEntity>
            {
                Ids = entityIds,
            };

        criteria.SetAsNoTracking();

        var includes =
            GetInclude();

        criteria
            .SetInclude(
                includes
            );

        using var transaction =
            await
                transactionManager
                    .BeginTransaction();

        await
            PrepareOnUpdate(
                updateEntities
            );

        var updatedEntityList =
            updateConverter
                .Convert(
                    updateEntities
                );

        var updatedCount =
            await
                repository
                    .UpdateCollectionAsync(
                        updatedEntityList
                    );

        var changedEntityIds =
            updatedEntityList
                .Select(
                    item =>
                        item.Id
                )
                .ToList();

        TableActionResultResponse result =
            new(
                updatedCount,
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

    protected virtual
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? GetInclude() =>
        default;

    protected virtual Task PrepareOnUpdate(
        IReadOnlyList<TUpdateEntityRequest> updateEntities
    ) =>
        Task.CompletedTask;

    protected virtual Task ValidateOnUpdate(
        IReadOnlyList<TUpdateEntityRequest> updateEntities,
        ArcIdentity identity
    )
    {
        if (updateEntities.IsEmpty())
        {
            throw
                badDataExceptionDescriptor
                    .CreateException(
                        "Empty list of update entities"
                    );
        }

        return
            Task.CompletedTask;
    }
}