using Arc.Criteria.FilterParameters.Implementations.Base;

namespace Arc.Criteria.FilterParameters.Implementations;

public sealed class DateTimeRangeFilterParameter<TEntity> :
    FilterParameterBase<TEntity>
{
    public override Expression<Func<TEntity, bool>> GetPredicate() =>
        PredicateBuilder
            .New<TEntity>()
            .Start(
                entity =>
                    _includeDefaultValueForEmptyFilter
                    && _getPropertyFunction
                        .Invoke(
                            entity
                        )
                    == default
            )
            .Or(
                entity =>
                    (_fromDate == default
                        || _fromDate
                        <= _getPropertyFunction
                            .Invoke(
                                entity
                            ))
                    && (_toDate == default
                        || _toDate
                        >= _getPropertyFunction
                            .Invoke(
                                entity
                            ))
            );

#region Constructors

    private readonly DateTime
        _fromDate;

    private readonly DateTime
        _toDate;

    private readonly Expression
        <
            Func<TEntity, DateTime>
        >
        _getPropertyFunction;

    private readonly bool
        _includeDefaultValueForEmptyFilter;

    public DateTimeRangeFilterParameter(
        DateTime
            fromDate,
        DateTime
            toDate,
        Expression
            <
                Func<TEntity, DateTime>
            >
            getPropertyFunction,
        bool includeDefaultValueForEmptyFilter = false
    )
    {
        _fromDate =
            fromDate;

        _toDate =
            toDate;

        _getPropertyFunction =
            getPropertyFunction;

        var isEmptyFromDate =
            _fromDate == default;

        var isEmptyToDate =
            _toDate == default;

        var isEmptyDates =
            isEmptyFromDate
            && isEmptyToDate;

        _includeDefaultValueForEmptyFilter =
            includeDefaultValueForEmptyFilter
            || isEmptyDates;
    }

#endregion
}