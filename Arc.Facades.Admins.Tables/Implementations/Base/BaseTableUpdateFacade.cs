using Arc.Converters.Base.Interfaces;
using Arc.Criteria.Implementations;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Common.Extensions;
using Arc.Infrastructure.Common.Interfaces;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Infrastructure.Repositories.Interfaces;
using Arc.Infrastructure.Transactions.Interfaces;
using Arc.Models.BusinessLogic.Models.Identities;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.Views.Admins.Models;

using Microsoft.EntityFrameworkCore.Query;

namespace Arc.Facades.Admins.Tables.Implementations.Base;

public abstract class BaseTableUpdateFacade
<
    TEntity,
    TUpdateEntityRequest
>
    where TEntity : class, IWithIdentifier
    where TUpdateEntityRequest : IWithIdentifier
{
    protected async Task<Response> Execute(
        IReadOnlyList<TUpdateEntityRequest> updateEntities,
        AdminIdentity identity
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
                _transactionManager
                    .BeginTransaction();

        await
            PrepareOnUpdate(
                updateEntities
            );

        var updatedEntityList =
            _updateConverter
                .Convert(
                    updateEntities
                );

        var updatedCount =
            await
                _repository
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
            _internalFacade
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
        AdminIdentity identity
    )
    {
        if (updateEntities.IsEmpty())
        {
            throw
                _badDataExceptionDescriptor
                    .CreateException(
                        "Empty list of update entities"
                    );
        }

        return
            Task.CompletedTask;
    }

#region Constructor

    private readonly IResponsesDomainFacade
        _internalFacade;

    private readonly IUpdateRepository
        _repository;

    private readonly ITransactionManager
        _transactionManager;

    private readonly IConverterBase<TUpdateEntityRequest, TEntity>
        _updateConverter;

    private readonly IBadDataExceptionDescriptor
        _badDataExceptionDescriptor;

    protected BaseTableUpdateFacade(
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
    {
        _repository =
            repository;

        _internalFacade =
            internalFacade;

        _updateConverter =
            updateConverter;

        _transactionManager =
            transactionManager;

        _badDataExceptionDescriptor =
            badDataExceptionDescriptor;
    }

#endregion
}