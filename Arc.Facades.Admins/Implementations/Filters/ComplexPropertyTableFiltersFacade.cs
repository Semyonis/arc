using Arc.Facades.Admins.Interfaces.Filters;
using Arc.Facades.Domain.Interface;
using Arc.Models.BusinessLogic.Models.FilterProperties;
using Arc.Models.BusinessLogic.Models.Identities;
using Arc.Models.BusinessLogic.Response;

using static Arc.Infrastructure.Common.Constants.Filters.FilterPropertyType;
using static Arc.Infrastructure.Common.Constants.EntityProperties.ComplexPropertyFilterPropertyStringConstants;

namespace Arc.Facades.Admins.Implementations.Filters;

public sealed class ComplexPropertyTableFiltersFacade :
    IComplexPropertyTableFiltersFacade
{
    private readonly IResponsesDomainFacade
        _internalFacade;

    public ComplexPropertyTableFiltersFacade(
        IResponsesDomainFacade
            internalFacade
    ) =>
        _internalFacade =
            internalFacade;

    public Task Validate(
        AdminIdentity identity
    ) =>
        Task.CompletedTask;

    public Task<Response> Execute()
    {
        var id =
            new FilterPropertyTypeModel(
                "Id",
                ComplexPropertyIdentifier,
                Integer
            );

        var name =
            new FilterPropertyTypeModel(
                "Name",
                ComplexPropertyName,
                String
            );

        var tests =
            new FilterPropertyTypeModel(
                "Groups",
                ComplexPropertyGroupConstant,
                Item
            );

        var filterSettings =
            new[]
            {
                id,
                name,
                tests,
            };

        var responseDto =
            _internalFacade
                .CreateOkResponse(
                    filterSettings
                );

        return
            Task
                .FromResult(
                    responseDto
                );
    }
}