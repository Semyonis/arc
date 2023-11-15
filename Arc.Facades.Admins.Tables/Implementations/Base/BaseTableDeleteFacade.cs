using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Common.Interfaces;
using Arc.Infrastructure.Repositories.Interfaces;
using Arc.Infrastructure.Repositories.Read.Interfaces.Base;
using Arc.Infrastructure.Transactions.Interfaces;
using Arc.Models.BusinessLogic.Models.Identities;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.Views.Admins.Models;

using Microsoft.EntityFrameworkCore.Query;

namespace Arc.Facades.Admins.Tables.Implementations.Base;

public abstract class BaseTableDeleteFacade<TEntity>(
    IDeleteRepository
        repository,
    IResponsesDomainFacade
        internalFacade,
    ITransactionManager
        transactionManager,
    IReadRepositoryBase<TEntity>
        readRepository
)
    where TEntity : class, IWithIdentifier
{
    public async Task<Response> Execute(
        IReadOnlyList<int> ids,
        AdminIdentity identity
    )
    {
        await
            ValidateOnDelete(
                ids,
                identity
            );

        using var transaction =
            await
                transactionManager
                    .BeginTransaction();

        await
            PrepareOnDelete(
                ids
            );

        var includes =
            GetInclude();

        var entitiesList =
            await
                readRepository
                    .GetByIds(
                        ids,
                        includes
                    );

        var deletedCount =
            await
                repository
                    .DeleteCollectionAsync(
                        entitiesList
                    );

        var changedEntityIds =
            entitiesList
                .Select(
                    item =>
                        item.Id
                )
                .ToList();

        TableActionResultResponse result =
            new(
                deletedCount,
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

    protected virtual Task PrepareOnDelete(
        IReadOnlyList<int> ids
    ) =>
        Task.CompletedTask;

    protected virtual Task ValidateOnDelete(
        IReadOnlyList<int> ids,
        AdminIdentity identity
    ) =>
        Task.CompletedTask;
}