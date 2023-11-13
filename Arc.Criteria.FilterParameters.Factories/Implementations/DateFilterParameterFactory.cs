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

public class DateFilterParameterFactory :
    IDateFilterParameterFactory
{
    public FilterParameterBase<TEntity> GetFilterParameter
    <
        TEntity
    >(
        FilterPropertyRequestModel filter,
        Expression
        <
            Func<TEntity, DateTime>
        > propertyPredicate
    )
    {
        if (filter.Operation == InRange)
        {
            var range =
                _serializationDecorator
                    .Deserialize
                    <
                        DateTimeRangeModel
                    >(
                        filter.Value
                    );

            if (range == default)
            {
                throw
                    _badDataExceptionDescriptor.CreateException();
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
                    _dateCompareFunctions.GetFunction(
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
                    _badDataExceptionDescriptor.CreateException();
        }
    }

#region Constructor

    private readonly IBadDataExceptionDescriptor
        _badDataExceptionDescriptor;

    private readonly IDateCompareFunctions
        _dateCompareFunctions;

    private readonly ISerializationDecorator
        _serializationDecorator;

    public DateFilterParameterFactory(
        ISerializationDecorator
            serializationDecorator,
        IBadDataExceptionDescriptor
            badDataExceptionDescriptor,
        IDateCompareFunctions
            dateCompareFunctions
    )
    {
        _serializationDecorator =
            serializationDecorator;

        _badDataExceptionDescriptor =
            badDataExceptionDescriptor;

        _dateCompareFunctions =
            dateCompareFunctions;
    }

#endregion
}