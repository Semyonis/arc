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
>
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
            _createConverter
                .Convert(
                    newEntities
                );

        using var transaction =
            await
                _transactionManager
                    .BeginTransaction();

        var createdCount =
            await
                _repository
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
            _internalFacade
                .CreateOkResponse(
                    result
                );
    }

    protected virtual Task ValidateOnCreate(
        IReadOnlyList<TCreateEntityRequest> createEntities,
        AdminIdentity identity
    ) =>
        Task.CompletedTask;

#region Constructor

    private readonly IConverterBase<TCreateEntityRequest, TEntity>
        _createConverter;

    private readonly IResponsesDomainFacade
        _internalFacade;

    private readonly ICreateRepository
        _repository;

    private readonly ITransactionManager
        _transactionManager;

    protected BaseTableCreateFacade(
        ICreateRepository
            repository,
        IResponsesDomainFacade
            internalFacade,
        IConverterBase<TCreateEntityRequest, TEntity>
            createConverter,
        ITransactionManager
            transactionManager
    )
    {
        _repository =
            repository;

        _internalFacade =
            internalFacade;

        _createConverter =
            createConverter;

        _transactionManager =
            transactionManager;
    }

#endregion
}