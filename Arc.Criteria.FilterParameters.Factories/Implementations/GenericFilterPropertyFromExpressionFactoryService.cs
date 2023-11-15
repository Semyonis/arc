using System.Reflection;

using Arc.Criteria.CompareFunctions.Interfaces;
using Arc.Criteria.FilterParameters.Factories.Interfaces;
using Arc.Criteria.FilterParameters.Implementations;
using Arc.Criteria.FilterParameters.Implementations.Base;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Models.BusinessLogic.Models.FilterProperties;

namespace Arc.Criteria.FilterParameters.Factories.Implementations;

/// <summary>
/// For internal use in ReadRepository
/// </summary>
public sealed class GenericFilterPropertyFromExpressionFactoryService(
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
    )
    :
        IGenericFilterPropertyFromExpressionFactoryService
{
   public FilterParameterBase<TEntity> GetProperty<TEntity, TProperty>(
        Expression<Func<TEntity, TProperty>> expression,
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
                expression
            );
    }

    private PropertyFilterParameter<TEntity, TProperty> GetFilterParameter
        <
            TEntity,
            TProperty
        >
    (
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

        // todo : should reworked in some way. this check duplicates same in GenericFilterPropertyFromStringValueFactoryService
        var isBool =
            propertyType
            == typeof(bool);

        if (isBool)
        {
            return
                GetBoolFilterParameter<TEntity>(
                    operation,
                    template,
                    convertedProperty
                );
        }

        var isInteger =
            propertyType
            == typeof(int);

        if (isInteger)
        {
            return
                GetIntegerFilterParameter<TEntity>(
                    operation,
                    template,
                    convertedProperty
                );
        }

        var isString =
            propertyType
            == typeof(string);

        if (isString)
        {
            return
                GetStringFilterParameter<TEntity>(
                    operation,
                    template,
                    convertedProperty
                );
        }

        var isDateTime =
            propertyType
            == typeof(DateTime);

        if (isDateTime)
        {
            return
                GetDateTimeFilterParameter<TEntity>(
                    operation,
                    template,
                    convertedProperty
                );
        }

        throw
            badDataExceptionDescriptor.CreateException();
    }

    private  Type GetPropertyType<TEntity, TProperty>(
        Expression<Func<TEntity, TProperty>> propertyLambda
    )
    {
        if (propertyLambda.Body is MemberExpression memberExpression)
        {
            var propertyInfo =
                (PropertyInfo)memberExpression.Member;

            return propertyInfo.PropertyType;
        }

        throw
            badDataExceptionDescriptor.CreateException();
    }
    private PropertyFilterParameter<TEntity, bool> GetBoolFilterParameter<TEntity>(
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
        var filterPropertyModel =
            new DateTimeFilterPropertyModel(
                operation,
                template
            );

        return
            dateTimeFilterParameterFactory
                .GetFilterParameter(
                    filterPropertyModel,
                    property
                );
    }
}