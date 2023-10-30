using Arc.Criteria.CompareFunctions.Interfaces;
using Arc.Criteria.FilterParameters.Factories.Interfaces;
using Arc.Criteria.FilterParameters.Implementations;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Models.BusinessLogic.Models.FilterProperties;
using Arc.Models.DataBase.Models;

using static Arc.Infrastructure.Common.Constants.EntityProperties.GroupFilterPropertyStringConstants;
using static Arc.Infrastructure.Entity.Expressions.Extensions.Implementations.GroupExpressions;

namespace Arc.Criteria.FilterParameters.Factories.Implementations;

public sealed class GroupFilterPropertyFactoryService :
    IGroupFilterParameterFactoryService
{
    public IReadOnlyList<FilterParameterBase<Group>> GetProperties(
        IReadOnlyList<FilterPropertyRequestModel> models
    ) =>
        models
            .Select(
                GetProperty
            )
            .ToList();

    private FilterParameterBase<Group> GetProperty(
        FilterPropertyRequestModel filter
    ) =>
        filter.Property switch
        {
            GroupIdentifier =>
                GetGroupIdentifier(
                    filter
                ),
            GroupName =>
                GetGroupName(
                    filter
                ),
            _ =>
                throw
                    _badDataExceptionDescriptor.CreateException(),
        };

    private PropertyFilterParameter<Group, string> GetGroupName(
        FilterPropertyRequestModel filter
    )
    {
        var compareFunction =
            _stringCompareFunctions
                .GetFunction(
                    filter.Operation
                );

        return new(
            GetName(),
            compareFunction,
            filter.Value
        );
    }

    private PropertyFilterParameter<Group, int> GetGroupIdentifier(
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

    public GroupFilterPropertyFactoryService(
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