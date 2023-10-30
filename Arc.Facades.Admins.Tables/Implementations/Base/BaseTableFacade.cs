using Arc.Converters.Base.Interfaces;
using Arc.Converters.Views.Common.Interfaces;
using Arc.Criteria.FilterParameters.Factories.Interfaces;
using Arc.Facades.Domain.Args;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Common.Interfaces;
using Arc.Infrastructure.Repositories.Read.Interfaces.Base;
using Arc.Infrastructure.Services.Interfaces;
using Arc.Models.BusinessLogic.Models.Identities;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.DataBase;
using Arc.Models.Views.Common.Models;

using Microsoft.EntityFrameworkCore.Query;

namespace Arc.Facades.Admins.Tables.Implementations.Base;

public abstract class BaseTableFacade
<
    TEntity,
    TReadEntityResponse
>
    where TEntity : class, IWithIdentifier
{
    public async Task<Response> Execute(
        TableReadRequest request,
        AdminIdentity identity
    )
    {
        var filterModels =
            _filterPropertyRequestRequestToFilterPropertyRequestModelConverter
                .Convert(
                    request.Filters
                );

        var filters =
            _baseFilterPropertyRequestRequestToBaseFilterParameterConverter
                .GetProperties(
                    filterModels
                );

        var totalCount =
            await
                _readRepository
                    .GetCountByFiltersAsync(
                        filters
                    );

        var orderingParam =
            _orderingService
                .GetOrderingExpression
                <
                    TEntity,
                    TableReadRequest
                >(
                    request
                );

        var includes =
            GetInclude();

        var paginationIn =
            PaginationIn
                .GetPagination(
                    request.CurrentPage,
                    request.CountPerPage
                );

        var entityList =
            await
                _readRepository
                    .GetListByFiltersAsync(
                        filters,
                        includes,
                        true,
                        paginationIn,
                        orderingParam
                    );

        var responsePage =
            _readConverter
                .Convert(
                    entityList
                );

        var paginationOut =
            PaginationOut
                .GetPagination(
                    request.CurrentPage,
                    request.CountPerPage,
                    totalCount
                );

        var args =
            new PageResponsesDomainFacadeArgs<TReadEntityResponse>(
                responsePage,
                paginationOut
            );

        return
            _internalResponsesFacade
                .CreatePageResponse(
                    args
                );
    }

    protected virtual
        Func
        <
            IQueryable<TEntity>,
            IIncludableQueryable<TEntity, object>
        >? GetInclude() => default;

#region Constructor

    private readonly IConverterBase<TEntity, TReadEntityResponse>
        _readConverter;

    private readonly IPageResponsesDomainFacade
        _internalResponsesFacade;

    private readonly IOrderingService
        _orderingService;

    private readonly IReadRepositoryBase<TEntity>
        _readRepository;

    private readonly IBaseFilterParameterFactoryService<TEntity>
        _baseFilterPropertyRequestRequestToBaseFilterParameterConverter;

    private readonly IFilterPropertyRequestRequestToFilterPropertyRequestModelConverter
        _filterPropertyRequestRequestToFilterPropertyRequestModelConverter;

    protected BaseTableFacade(
        IReadRepositoryBase<TEntity>
            readRepository,
        IPageResponsesDomainFacade
            internalResponsesFacade,
        IConverterBase<TEntity, TReadEntityResponse>
            readConverter,
        IOrderingService
            orderingService,
        IBaseFilterParameterFactoryService<TEntity>
            baseFilterPropertyRequestRequestToBaseFilterParameterConverter,
        IFilterPropertyRequestRequestToFilterPropertyRequestModelConverter
            filterPropertyRequestRequestToFilterPropertyRequestModelConverter
    )
    {
        _readRepository =
            readRepository;

        _internalResponsesFacade =
            internalResponsesFacade;

        _readConverter =
            readConverter;

        _orderingService =
            orderingService;

        _baseFilterPropertyRequestRequestToBaseFilterParameterConverter =
            baseFilterPropertyRequestRequestToBaseFilterParameterConverter;

        _filterPropertyRequestRequestToFilterPropertyRequestModelConverter =
            filterPropertyRequestRequestToFilterPropertyRequestModelConverter;
    }

#endregion
}