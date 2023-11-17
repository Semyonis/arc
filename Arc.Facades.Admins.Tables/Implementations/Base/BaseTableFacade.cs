using Arc.Converters.Base.Interfaces;
using Arc.Converters.Views.Common.Interfaces;
using Arc.Criteria.FilterParameters.Factories.Generic.Interfaces;
using Arc.Criteria.FilterParameters.Implementations.Base;
using Arc.Facades.Domain.Args;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Common.Interfaces;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Infrastructure.Repositories.Read.Interfaces.Base;
using Arc.Infrastructure.Services.Interfaces;
using Arc.Models.BusinessLogic.Models.FilterProperties;
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
>(
    IReadRepositoryBase<TEntity>
        readRepository,
    IPageResponsesDomainFacade
        internalResponsesFacade,
    IConverterBase<TEntity, TReadEntityResponse>
        readConverter,
    IOrderingService
        orderingService,
    IGenericPropertyLambdaSelector
        basePropertyRequestRequestToBaseParameterConverter,
    IFilterPropertyRequestRequestToFilterPropertyRequestModelConverter
        filterPropertyRequestRequestToFilterPropertyRequestModelConverter,
    IGenericFilterPropertyFactory
        genericFilterPropertyFactory,
    IBadDataExceptionDescriptor
        badDataExceptionDescriptor
)
    where TEntity : class, IWithIdentifier
{
    public async Task<Response> Execute(
        TableReadRequest request,
        AdminIdentity identity
    )
    {
        var filterModels =
            filterPropertyRequestRequestToFilterPropertyRequestModelConverter
                .Convert(
                    request.Filters
                );

        var filters =
            GetFilterParameters(
                filterModels
        );

        var totalCount =
            await
                readRepository
                    .GetCountByFiltersAsync(
                        filters
                    );

        var resultContainer =
            orderingService
                .GetOrderingExpression
                <
                    TEntity,
                    TableReadRequest
                >(
                    request
                );

        if (!resultContainer.IsSuccess)
        {
            throw
                badDataExceptionDescriptor.CreateException();
        }

        var orderingParam =
            resultContainer.Value;

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
                readRepository
                    .GetListByFiltersAsync(
                        filters,
                        includes,
                        true,
                        paginationIn,
                        orderingParam
                    );

        var responsePage =
            readConverter
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
            internalResponsesFacade
                .CreatePageResponse(
                    args
                );
    }

    private List<FilterParameterBase<TEntity>> GetFilterParameters(
        IReadOnlyList<FilterPropertyRequestModel> filterModels
    )
    {
        var filters =
            new List<FilterParameterBase<TEntity>>();

        foreach (var filterModel in filterModels)
        {
            var resultContainer =
                basePropertyRequestRequestToBaseParameterConverter
                    .GetLambda<TEntity>(
                        filterModel.Property
                    );

            if (!resultContainer.IsSuccess)
            {
                throw
                    badDataExceptionDescriptor.CreateException();

            }

            var filterPropertyModel =
                new FilterPropertyModel(
                    filterModel.Operation,
                    filterModel.Value
                );

            var filter =
                genericFilterPropertyFactory
                    .GetProperty(
                        resultContainer.Value,
                        filterPropertyModel
                    );

            filters
                .Add(
                    filter
                );
        }

        return filters;
    }

    protected virtual
        Func
        <
            IQueryable<TEntity>,
            IIncludableQueryable<TEntity, object>
        >? GetInclude() => default;
}