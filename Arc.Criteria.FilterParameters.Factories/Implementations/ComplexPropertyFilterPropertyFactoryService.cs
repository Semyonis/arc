using Arc.Criteria.CompareFunctions.Interfaces;
using Arc.Criteria.FilterParameters.Factories.Interfaces;
using Arc.Criteria.FilterParameters.Implementations;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Models.BusinessLogic.Models.FilterProperties;
using Arc.Models.DataBase.Models;

using static Arc.Infrastructure.Common.Constants.EntityProperties.ComplexPropertyFilterPropertyStringConstants;
using static Arc.Infrastructure.Entity.Expressions.Extensions.Implementations.ComplexPropertyExpressions;

namespace Arc.Criteria.FilterParameters.Factories.Implementations;

public sealed class ComplexPropertyFilterPropertyFactoryService :
    IComplexPropertyFilterParameterFactoryService
{
    public IReadOnlyList<FilterParameterBase<ComplexProperty>> GetProperties(
        IReadOnlyList<FilterPropertyRequestModel> models
    ) =>
        models
            .Select(
                GetProperty
            )
            .ToList();

    private FilterParameterBase<ComplexProperty> GetProperty(
        FilterPropertyRequestModel filter
    ) =>
        filter.Property switch
        {
            ComplexPropertyIdentifier =>
                GetComplexPropertyIdentifier(
                    filter
                ),
            ComplexPropertyName =>
                GetComplexPropertyName(
                    filter
                ),
            _ =>
                throw
                    _badDataExceptionDescriptor.CreateException(),
        };

    private PropertyFilterParameter<ComplexProperty, string> GetComplexPropertyName(
        FilterPropertyRequestModel filter
    )
    {
        var compareFunction =
            _stringCompareFunctions
                .GetFunction(
                    filter.Operation
                );

        return new(
            GetValue(),
            compareFunction,
            filter.Value
        );
    }

    private PropertyFilterParameter<ComplexProperty, int> GetComplexPropertyIdentifier(
        FilterPropertyRequestModel filter
    )
    {
        var compareFunction =
            _integerCompareFunctions
                .GetFunction(
                    filter.Operation
                );

        var value =
            filter
                .Value
                .ParseToNullableInteger()!
                .Value;

        return new(
            GetId(),
            compareFunction,
            value
        );
    }

#region Constructor

    private readonly IBadDataExceptionDescriptor
        _badDataExceptionDescriptor;

    private readonly IIntegerCompareFunctions
        _integerCompareFunctions;

    private readonly IStringCompareFunctions
        _stringCompareFunctions;

    public ComplexPropertyFilterPropertyFactoryService(
        IBadDataExceptionDescriptor
            badDataExceptionDescriptor,
        IIntegerCompareFunctions
            integerCompareFunctions,
        IStringCompareFunctions
            stringCompareFunctions
    )
    {
        _badDataExceptionDescriptor =
            badDataExceptionDescriptor;

        _integerCompareFunctions =
            integerCompareFunctions;

        _stringCompareFunctions =
            stringCompareFunctions;
    }

#endregion
}