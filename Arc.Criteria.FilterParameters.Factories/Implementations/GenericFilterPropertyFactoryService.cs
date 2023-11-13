using Arc.Criteria.CompareFunctions.Interfaces;
using Arc.Criteria.FilterParameters.Factories.Interfaces;
using Arc.Criteria.FilterParameters.Implementations;
using Arc.Criteria.FilterParameters.Implementations.Base;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Models.BusinessLogic.Models.FilterProperties;

namespace Arc.Criteria.FilterParameters.Factories.Implementations;

public sealed class GenericFilterPropertyFactoryService : 
    IGenericFilterPropertyFactoryService
{
    public IReadOnlyList<FilterParameterBase<TEntity>> GetProperties<TEntity>(
        IReadOnlyList<FilterPropertyRequestModel> models
    ) =>
        models
            .Select(
                GetProperty<TEntity>
            )
            .ToList();

    public FilterParameterBase<TEntity> GetProperty<TEntity>(
        FilterPropertyRequestModel filter
    )
    {
        var entityType =
            typeof(TEntity);

        var propertyInfo =
            entityType
                .GetProperty(
                    filter.Property
                );

        var propertyType =
            propertyInfo!.PropertyType;

        var isInteger =
            propertyType
                .IsAssignableFrom(
                    typeof(int)
                );

        if (isInteger)
        {
            Func
            <
                string,
                string,
                Expression<Func<TEntity, int>>,
                PropertyFilterParameter<TEntity, int>
            > action =
                GetIntegerFilterParameter<TEntity>;

            return
                GetFilterParameterBase(
                filter,
                action
            );
        }

        var isString =
            propertyType
                .IsAssignableFrom(
                    typeof(string)
                );

        if (isString)
        {
            Func
            <
                string,
                string,
                Expression<Func<TEntity, string>>,
                PropertyFilterParameter<TEntity, string>
            > action =
                GetStringFilterParameter<TEntity>;

            return
                GetFilterParameterBase(
                    filter,
                    action
                );
        }

        throw
            _badDataExceptionDescriptor.CreateException();
    }

    private static FilterParameterBase<TEntity> GetFilterParameterBase<TEntity, TProperty>(
        FilterPropertyRequestModel filter,
        Func<string, string, Expression<Func<TEntity, TProperty>>, PropertyFilterParameter<TEntity, TProperty>> action
    )
    {
        var item =
            Expression
                .Parameter(
                    typeof(TEntity),
                    "entity"
                );

        var prop =
            Expression
                .Property(
                    item,
                    filter.Property
                );

        Expression<Func<TEntity, TProperty>> getPropertyLambda =
            Expression
                .Lambda<Func<TEntity, TProperty>>(
                    prop,
                    item
                );

        return
            action(
                filter.Operation,
                filter.Value,
                getPropertyLambda
            );
    }

    private PropertyFilterParameter<TEntity, int> GetIntegerFilterParameter<TEntity>(
        string operation,
        string template,
        Expression
        <
            Func<TEntity, int>
        > property
    )
    {
        var compareFunction =
            _integerCompareFunctions
                .GetFunction(
                    operation
                );

        var value =
            template
                .ParseToNullableInteger()!
                .Value;

        return new(
            property,
            compareFunction,
            value
        );
    }

    private PropertyFilterParameter<TEntity, string> GetStringFilterParameter<TEntity>(
        string operation,
        string template,
        Expression
        <
            Func<TEntity, string>
        > property
    )
    {
        var compareFunction =
            _stringCompareFunctions
                .GetFunction(
                    operation
                );

        return new(
            property,
            compareFunction,
            template
        );
    }

#region Constructor

    private readonly IBadDataExceptionDescriptor
        _badDataExceptionDescriptor;

    private readonly IBoolCompareFunctions
        _boolCompareFunctions;

    private readonly IDateCompareFunctions
        _dateCompareFunctions;

    private readonly IEnumerationCompareFunctions
        _enumerationCompareFunctions;

    private readonly IIntegerCompareFunctions
        _integerCompareFunctions;

    private readonly IStringCompareFunctions
        _stringCompareFunctions;

    public GenericFilterPropertyFactoryService(
        IBadDataExceptionDescriptor
            badDataExceptionDescriptor,
        IIntegerCompareFunctions
            integerCompareFunctions,
        IStringCompareFunctions
            stringCompareFunctions,
        IBoolCompareFunctions
            boolCompareFunctions,
        IDateCompareFunctions
            dateCompareFunctions,
        IEnumerationCompareFunctions
            enumerationCompareFunctions
    )
    {
        _badDataExceptionDescriptor =
            badDataExceptionDescriptor;

        _integerCompareFunctions =
            integerCompareFunctions;

        _stringCompareFunctions =
            stringCompareFunctions;

        _boolCompareFunctions =
            boolCompareFunctions;

        _dateCompareFunctions =
            dateCompareFunctions;
        
        _enumerationCompareFunctions =
            enumerationCompareFunctions;
    }

#endregion
}