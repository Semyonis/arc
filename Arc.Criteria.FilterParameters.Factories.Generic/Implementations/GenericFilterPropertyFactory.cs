using System.Reflection;

using Arc.Criteria.CompareFunctions.Interfaces;
using Arc.Criteria.FilterParameters.Factories.Generic.Interfaces;
using Arc.Criteria.FilterParameters.Factories.Interfaces;
using Arc.Criteria.FilterParameters.Implementations;
using Arc.Criteria.FilterParameters.Implementations.Base;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Models.BusinessLogic.Models.FilterProperties;

namespace Arc.Criteria.FilterParameters.Factories.Generic.Implementations;

public sealed class GenericFilterPropertyFactory(
    IBadDataExceptionDescriptor
        badDataExceptionDescriptor,
    IIntegerCompareFunctions
        integerCompareFunctions,
    IStringCompareFunctions
        stringCompareFunctions,
    IBooleanCompareFunctions
        booleanCompareFunctions,
    IDateTimeFilterParameterFactory
        dateTimeFilterParameterFactory
) : IGenericFilterPropertyFactory
{
    public FilterParameterBase<TEntity> GetProperty<TEntity, TProperty>(
        Expression<Func<TEntity, TProperty>> lambdaExpression,
        FilterPropertyModel filter
    )
    {
        Func
        <
            string,
            string,
            Expression<Func<TEntity, TProperty>>,
            PropertyFilterParameter<TEntity, TProperty>
        > action = GetFilterParameter;

        (
            var operation,
            var value
        ) = filter;

        return
            action(
                operation,
                value,
                lambdaExpression
            );
    }

    private PropertyFilterParameter<TEntity, TProperty> GetFilterParameter
    <
        TEntity,
        TProperty
    >(
        string operation,
        string template,
        Expression<Func<TEntity, TProperty>> property
    )
    {
        dynamic convertedProperty =
            property;

        var propertyType =
            GetPropertyType(
                property
            );

        return
            GetFilterParameter<TEntity, TProperty>(
                operation,
                template,
                convertedProperty,
                propertyType
            );
    }

    private Type GetPropertyType<TEntity, TProperty>(
        Expression<Func<TEntity, TProperty>> propertyLambda
    )
    {
        if (propertyLambda.Body is MemberExpression memberExpression)
        {
            var propertyInfo =
                (PropertyInfo)memberExpression.Member;

            return
                propertyInfo.PropertyType;
        }

        throw
            badDataExceptionDescriptor.CreateException();
    }

    private PropertyFilterParameter<TEntity, TProperty> GetFilterParameter<TEntity, TProperty>(
        string operation,
        string template,
        dynamic convertedProperty,
        Type propertyType
    ) =>
        propertyType switch
        {
            not null when propertyType == typeof(bool) =>
                GetBooleanFilterParameter<TEntity>(
                    operation,
                    template,
                    convertedProperty
                ),
            not null when propertyType == typeof(int) =>
                GetIntegerFilterParameter<TEntity>(
                    operation,
                    template,
                    convertedProperty
                ),
            not null when propertyType == typeof(string) =>
                GetStringFilterParameter<TEntity>(
                    operation,
                    template,
                    convertedProperty
                ),
            not null when propertyType == typeof(DateTime) =>
                GetDateTimeFilterParameter<TEntity>(
                    operation,
                    template,
                    convertedProperty
                ),
            _ => throw
                badDataExceptionDescriptor.CreateException(),
        };

    private PropertyFilterParameter<TEntity, bool> GetBooleanFilterParameter<TEntity>(
        string operation,
        string template,
        Expression<Func<TEntity, bool>> property
    )
    {
        var compareFunction =
            booleanCompareFunctions
                .GetFunction(
                    operation
                );

        var value =
            bool
                .Parse(
                    template
                );

        return new(
            property,
            compareFunction,
            value
        );
    }

    private PropertyFilterParameter<TEntity, int> GetIntegerFilterParameter<TEntity>(
        string operation,
        string template,
        Expression<Func<TEntity, int>> property
    )
    {
        var compareFunction =
            integerCompareFunctions
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
        Expression<Func<TEntity, string>> property
    )
    {
        var compareFunction =
            stringCompareFunctions
                .GetFunction(
                    operation
                );

        return new(
            property,
            compareFunction,
            template
        );
    }

    private FilterParameterBase<TEntity> GetDateTimeFilterParameter<TEntity>(
        string operation,
        string template,
        Expression<Func<TEntity, DateTime>> property
    )
    {
        var dateTimeFilterPropertyModel =
            new DateTimeFilterPropertyModel(
                operation,
                template
            );

        return
            dateTimeFilterParameterFactory
                .GetFilterParameter(
                    dateTimeFilterPropertyModel,
                    property
                );
    }
}