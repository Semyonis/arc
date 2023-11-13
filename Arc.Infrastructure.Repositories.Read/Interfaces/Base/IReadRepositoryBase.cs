using System.Threading;

using Arc.Criteria.FilterParameters.Implementations.Base;
using Arc.Infrastructure.Common.Enums;
using Arc.Infrastructure.Common.Interfaces;
using Arc.Infrastructure.Common.Models;
using Arc.Models.DataBase;

namespace Arc.Infrastructure.Repositories.Read.Interfaces.Base;

public interface IReadRepositoryBase<TEntity>
    where TEntity : class, IWithIdentifier
{
    Task<TEntity?> GetById(
        int entityId,
        Func
            <
                IQueryable<TEntity>,
                IIncludableQueryable<TEntity, object>
            >?
            include = default,
        bool asNoTracking = true
    );

    Task<IReadOnlyList<TEntity>> GetByIds(
        IReadOnlyList<int> ids,
        Func
            <
                IQueryable<TEntity>,
                IIncludableQueryable<TEntity, object>
            >?
            include = default,
        bool asNoTracking = true
    );

    Task<int> GetCountByFiltersAsync(
        IReadOnlyList<FilterParameterBase<TEntity>>? filters = default,
        CancellationToken cancellationToken = default
    );

    Task<TEntity?> GeFirstByFiltersAsync(
        IReadOnlyList<FilterParameterBase<TEntity>>? filters = default,
        Func
        <
            IQueryable<TEntity>,
            IIncludableQueryable<TEntity, object>
        >? include = default,
        bool asNoTracking = true,
        PaginationIn? pagination = default,
        OrderingParam<TEntity>? orderingParam = default,
        OperationType operationType = OperationType.And
    );

    Task<IReadOnlyList<TEntity>> GetListByFiltersAsync(
        IReadOnlyList<FilterParameterBase<TEntity>>? filters = default,
        Func
        <
            IQueryable<TEntity>,
            IIncludableQueryable<TEntity, object>
        >? include = default,
        bool asNoTracking = true,
        PaginationIn? pagination = default,
        OrderingParam<TEntity>? orderingParam = default,
        OperationType operationType = OperationType.And
    );
}