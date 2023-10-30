using Arc.Criteria.FilterParameters.Factories.Interfaces;
using Arc.Criteria.FilterParameters.Implementations;
using Arc.Criteria.FilterParameters.Implementations.ItemListParameters;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Models.BusinessLogic.Models.FilterProperties;

using static Arc.Infrastructure.Common.Constants.Filters.FilterOperationConstants;

namespace Arc.Criteria.FilterParameters.Factories.Implementations;

public sealed class ItemListFilterParameterFactory :
    IItemListFilterParameterFactory
{
    public FilterParameterBase<TEntity> GetFilterParameter
    <
        TEntity,
        TProperty
    >(
        FilterPropertyRequestModel filter,
        Expression
        <
            Func<TEntity, ICollection<TProperty>>
        > collectionPropertyPredicate,
        Expression
        <
            Func<TProperty, int>
        > propertyValuePredicate
    )
    {
        switch (filter.Operation)
        {
            case Contains:
            {
                var value =
                    filter
                        .Value
                        .ParseToNullableInteger()!
                        .Value;

                return
                    new ItemListPropertyAnyFilterParameter
                    <
                        TEntity,
                        TProperty
                    >(
                        collectionPropertyPredicate,
                        propertyValuePredicate,
                        value
                    );
            }
            case NotContains:
            {
                var value =
                    filter
                        .Value
                        .ParseToNullableInteger()!
                        .Value;

                return
                    new ItemListPropertyAllFilterParameter
                    <
                        TEntity,
                        TProperty
                    >(
                        collectionPropertyPredicate,
                        propertyValuePredicate,
                        value
                    );
            }
            case IsEmpty:
                return
                    new ItemListPropertyIsEmptyFilterParameter
                    <
                        TEntity,
                        TProperty
                    >(
                        collectionPropertyPredicate
                    );
            case IsNotEmpty:
                return
                    new ItemListPropertyIsNotEmptyFilterParameter
                    <
                        TEntity,
                        TProperty
                    >(
                        collectionPropertyPredicate
                    );
            default:
                throw
                    _badDataExceptionDescriptor.CreateException();
        }
    }

#region Constructor

    private readonly IBadDataExceptionDescriptor
        _badDataExceptionDescriptor;

    public ItemListFilterParameterFactory(
        IBadDataExceptionDescriptor
            badDataExceptionDescriptor
    ) =>
        _badDataExceptionDescriptor =
            badDataExceptionDescriptor;

#endregion
}