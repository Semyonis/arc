using Arc.Criteria.CompareFunctions.Interfaces;
using Arc.Criteria.FilterParameters.Factories.Interfaces;
using Arc.Criteria.FilterParameters.Implementations;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Models.BusinessLogic.Models.FilterProperties;
using Arc.Models.DataBase.Models;

using static Arc.Infrastructure.Common.Constants.EntityProperties.ActorFilterPropertyStringConstants;
using static Arc.Infrastructure.Entity.Expressions.Extensions.Implementations.ActorExpressions;

namespace Arc.Criteria.FilterParameters.Factories.Implementations;

public sealed class ActorFilterPropertyFactoryService :
    IActorFilterParameterFactoryService
{
    public IReadOnlyList<FilterParameterBase<Actor>> GetProperties(
        IReadOnlyList<FilterPropertyRequestModel> models
    ) =>
        models
            .Select(
                GetProperty
            )
            .ToList();

    private FilterParameterBase<Actor> GetProperty(
        FilterPropertyRequestModel filter
    ) =>
        filter.Property switch
        {
            ActorIdentifier =>
                GetActorIdentifier(
                    filter
                ),
            ActorName =>
                GetActorEmail(
                    filter
                ),
            _ =>
                throw
                    _badDataExceptionDescriptor.CreateException(),
        };

    private PropertyFilterParameter<Actor, string> GetActorEmail(
        FilterPropertyRequestModel filter
    )
    {
        var compareFunction =
            _stringCompareFunctions
                .GetFunction(
                    filter.Operation
                );

        return new(
            GetEmail(),
            compareFunction,
            filter.Value
        );
    }

    private PropertyFilterParameter<Actor, int> GetActorIdentifier(
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

    public ActorFilterPropertyFactoryService(
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