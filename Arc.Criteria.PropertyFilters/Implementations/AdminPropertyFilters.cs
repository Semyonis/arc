using Arc.Criteria.FilterParameters.Factories.Interfaces;
using Arc.Criteria.FilterParameters.Implementations.Base;
using Arc.Criteria.PropertyFilters.Interfaces;
using Arc.Models.BusinessLogic.Models.FilterProperties;
using Arc.Models.DataBase.Models;

using static Arc.Infrastructure.Common.Constants.Filters.FilterOperationConstants;

namespace Arc.Criteria.PropertyFilters.Implementations;

public sealed class AdminPropertyFilters :
    IAdminPropertyFilters
{
    private readonly IGenericFilterPropertyFactoryService
        _genericFilterPropertyFactoryService;

    public AdminPropertyFilters(
        IGenericFilterPropertyFactoryService
            genericFilterPropertyFactoryService
    ) =>
        _genericFilterPropertyFactoryService =
            genericFilterPropertyFactoryService;

    public FilterParameterBase<Admin> GetEmailEqualFilter(
        string pattern
    )
    {
        const string Email =
            "Email";

        var filterPropertyRequestModel =
            new FilterPropertyRequestModel(
                Email,
                Equal,
                pattern
            );

        return 
            _genericFilterPropertyFactoryService
                .GetProperty<Admin>(
                    filterPropertyRequestModel
                );
    }
}