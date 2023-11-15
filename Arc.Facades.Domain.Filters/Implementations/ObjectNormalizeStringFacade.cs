using Arc.Facades.Domain.Filters.Interfaces;
using Arc.Infrastructure.Services.Interfaces;

namespace Arc.Facades.Domain.Filters.Implementations;

public sealed class ObjectNormalizeStringFacade(
    IStringNormalizationService
        stringNormalizationService
) : IObjectNormalizeStringFacade
{
    public object NormalizeStringFields(
        object value
    ) =>
        stringNormalizationService
            .Normalize(
                value
            );
}