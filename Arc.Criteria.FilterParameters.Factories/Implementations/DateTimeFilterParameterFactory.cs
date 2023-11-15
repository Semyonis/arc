using Arc.Criteria.CompareFunctions.Interfaces;
using Arc.Criteria.FilterParameters.Factories.Interfaces;
using Arc.Criteria.FilterParameters.Implementations;
using Arc.Criteria.FilterParameters.Implementations.Base;
using Arc.Dependencies.Json.Interfaces;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Models.BusinessLogic.Models;
using Arc.Models.BusinessLogic.Models.FilterProperties;

using static Arc.Infrastructure.Common.Constants.Filters.FilterOperationConstants;

namespace Arc.Criteria.FilterParameters.Factories.Implementations;

public class DateTimeFilterParameterFactory(
        ISerializationDecorator
            serializationDecorator,
        IBadDataExceptionDescriptor
            badDataExceptionDescriptor,
        IDateCompareFunctions
            dateCompareFunctions
    )
    :
        IDateTimeFilterParameterFactory
{
    public FilterParameterBase<TEntity> GetFilterParameter
    <
        TEntity
    >(
        DateTimeFilterPropertyModel filter,
        Expression
        <
            Func<TEntity, DateTime>
        > propertyPredicate
    )
    {
        if (filter.Operation == InRange)
        {
            var range =
                serializationDecorator
                    .Deserialize
                    <
                        DateTimeRangeModel
                    >(
                        filter.Value
                    );

            if (range == default)
            {
                throw
                    badDataExceptionDescriptor.CreateException();
            }

            return
                new DateTimeRangeFilterParameter
                <
                    TEntity
                >(
                    range.FromDate,
                    range.ToDate,
                    propertyPredicate
                );
        }

        switch (filter.Operation)
        {
            case Equal
                or NotEqual
                or Greater
                or Lower
                or GreaterOrEqual
                or LowerOrEqual:
            {
                var value =
                    DateTime.Parse(
                        filter.Value
                    );

                var compareFunction =
                    dateCompareFunctions.GetFunction(
                        filter.Operation
                    );

                return
                    new PropertyFilterParameter
                    <
                        TEntity,
                        DateTime
                    >(
                        propertyPredicate,
                        compareFunction,
                        value
                    );
            }
            default:
                throw
                    badDataExceptionDescriptor.CreateException();
        }
    }
}