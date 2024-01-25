using Arc.Facades.Admins.Interfaces.Filters;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Common.Constants.Filters;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Models.BusinessLogic.Models;
using Arc.Models.BusinessLogic.Models.FilterProperties;
using Arc.Models.BusinessLogic.Response;

using static Arc.Infrastructure.Common.Constants.Filters.FilterOperationConstants;
using static Arc.Infrastructure.Common.Constants.Filters.FilterPropertyType;

namespace Arc.Facades.Admins.Implementations.Filters;

public sealed class FilterPropertyOperationsFacade(
    IResponsesDomainFacade
        internalFacade,
    IBadDataExceptionDescriptor
        badDataExceptionDescriptor
) : IFilterPropertyOperationsFacade
{
    public Task Validate(
        ArcIdentity identity
    ) =>
        Task.CompletedTask;

    public Task<Response> Execute(
        string propertyType
    )
    {
        var operations =
            propertyType switch
            {
                Boolean =>
                    GetBooleanOperators(),
                Integer =>
                    GetIntegerOperators(),
                String =>
                    GetStringOperators(),
                Enumeration =>
                    GetEnumerationOperators(),
                Item =>
                    GetItemOperators(),
                ItemList =>
                    GetItemListOperators(),
                NullableBoolean =>
                    GetNullableBooleanOperators(),
                NullableInteger =>
                    GetNullableIntegerOperators(),
                NullableString =>
                    GetNullableStringOperators(),
                NullableEnumeration =>
                    GetNullableEnumerationOperators(),
                NullableItem =>
                    GetNullableItemOperators(),
                NullableItemList =>
                    GetNullableItemListOperators(),
                Date =>
                    GetDateListOperators(),
                _ =>
                    throw
                        badDataExceptionDescriptor.CreateException(),
            };

        var responseDto =
            internalFacade
                .CreateOkResponse(
                    operations
                );

        return
            Task
                .FromResult(
                    responseDto
                );
    }

    private static FilterPropertyOperatorModel[] GetBooleanOperators() =>
        new[]
        {
            GetEqualOperator(),
            GetNotEqualOperator(),
        };

    private static FilterPropertyOperatorModel[] GetIntegerOperators() =>
        new[]
        {
            GetEqualOperator(),
            GetNotEqualOperator(),
            GetGreaterOperator(),
            GetGreaterOrEqualOperator(),
            GetLowerOperator(),
            GetLowerOrEqualOperator(),
        };

    private static FilterPropertyOperatorModel[] GetStringOperators() =>
        new[]
        {
            GetContainsOperator(),
            GetNotContainsOperator(),
            GetEqualOperator(),
            GetNotEqualOperator(),
        };

    private static FilterPropertyOperatorModel[] GetEnumerationOperators() =>
        new[]
        {
            GetEqualOperator(),
            GetNotEqualOperator(),
        };

    private static FilterPropertyOperatorModel[] GetItemOperators() =>
        new[]
        {
            GetEqualOperator(),
            GetNotEqualOperator(),
        };

    private static FilterPropertyOperatorModel[] GetItemListOperators() =>
        new[]
        {
            GetContainsOperator(),
            GetNotContainsOperator(),
        };

    private static FilterPropertyOperatorModel[] GetNullableBooleanOperators() =>
        new[]
        {
            GetEqualOperator(),
            GetNotEqualOperator(),
            GetIsEmptyOperator(),
            GetIsNotEmptyOperator(),
        };

    private static FilterPropertyOperatorModel[] GetNullableIntegerOperators() =>
        new[]
        {
            GetEqualOperator(),
            GetNotEqualOperator(),
            GetGreaterOperator(),
            GetGreaterOrEqualOperator(),
            GetLowerOperator(),
            GetLowerOrEqualOperator(),
            GetIsEmptyOperator(),
            GetIsNotEmptyOperator(),
        };

    private static FilterPropertyOperatorModel[] GetNullableStringOperators() =>
        new[]
        {
            GetContainsOperator(),
            GetNotContainsOperator(),
            GetEqualOperator(),
            GetNotEqualOperator(),
            GetIsEmptyOperator(),
            GetIsNotEmptyOperator(),
        };

    private static FilterPropertyOperatorModel[] GetNullableEnumerationOperators() =>
        new[]
        {
            GetEqualOperator(),
            GetNotEqualOperator(),
            GetIsEmptyOperator(),
            GetIsNotEmptyOperator(),
        };

    private static FilterPropertyOperatorModel[] GetNullableItemOperators() =>
        new[]
        {
            GetEqualOperator(),
            GetNotEqualOperator(),
            GetIsEmptyOperator(),
            GetIsNotEmptyOperator(),
        };

    private static FilterPropertyOperatorModel[] GetNullableItemListOperators() =>
        new[]
        {
            GetContainsOperator(),
            GetNotContainsOperator(),
            GetIsEmptyOperator(),
            GetIsNotEmptyOperator(),
        };

    private static FilterPropertyOperatorModel[] GetDateListOperators() =>
        new[]
        {
            GetEqualOperator(),
            GetNotEqualOperator(),
            GetGreaterOperator(),
            GetGreaterOrEqualOperator(),
            GetLowerOperator(),
            GetLowerOrEqualOperator(),
            GetGetInRangeOperator(),
        };

    private static FilterPropertyOperatorModel GetEqualOperator() =>
        new(
            FilterOperationDesignationConstants.Equal,
            Equal
        );

    private static FilterPropertyOperatorModel GetNotEqualOperator() =>
        new(
            FilterOperationDesignationConstants.NotEqual,
            NotEqual
        );

    private static FilterPropertyOperatorModel GetContainsOperator() =>
        new(
            FilterOperationDesignationConstants.Contains,
            Contains
        );

    private static FilterPropertyOperatorModel GetNotContainsOperator() =>
        new(
            FilterOperationDesignationConstants.NotContains,
            NotContains
        );

    private static FilterPropertyOperatorModel GetGreaterOperator() =>
        new(
            FilterOperationDesignationConstants.Greater,
            Greater
        );

    private static FilterPropertyOperatorModel GetGreaterOrEqualOperator() =>
        new(
            FilterOperationDesignationConstants.GreaterOrEqual,
            GreaterOrEqual
        );

    private static FilterPropertyOperatorModel GetLowerOperator() =>
        new(
            FilterOperationDesignationConstants.Lower,
            Lower
        );

    private static FilterPropertyOperatorModel GetLowerOrEqualOperator() =>
        new(
            FilterOperationDesignationConstants.LowerOrEqual,
            LowerOrEqual
        );

    private static FilterPropertyOperatorModel GetIsEmptyOperator() =>
        new(
            FilterOperationDesignationConstants.IsEmpty,
            IsEmpty
        );

    private static FilterPropertyOperatorModel GetIsNotEmptyOperator() =>
        new(
            FilterOperationDesignationConstants.IsNotEmpty,
            IsNotEmpty
        );

    private static FilterPropertyOperatorModel GetGetInRangeOperator() =>
        new(
            FilterOperationDesignationConstants.InRange,
            InRange
        );
}