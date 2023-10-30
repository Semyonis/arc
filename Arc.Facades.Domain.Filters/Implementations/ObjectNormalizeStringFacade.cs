using Arc.Facades.Domain.Filters.Interfaces;
using Arc.Infrastructure.Services.Interfaces;

namespace Arc.Facades.Domain.Filters.Implementations;

public sealed class ObjectNormalizeStringFacade :
    IObjectNormalizeStringFacade
{
#region Constructor

    private readonly IStringNormalizationService
        _stringNormalizationService;

    public ObjectNormalizeStringFacade(
        IStringNormalizationService
            stringNormalizationService
    ) =>
        _stringNormalizationService =
            stringNormalizationService;

#endregion

    public object NormalizeStringFields(
        object value
    ) =>
        _stringNormalizationService
            .Normalize(
                value
            );
}