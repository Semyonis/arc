using System;

using Arc.Infrastructure.Common.Constants;

namespace Arc.Controllers.Base.Attributes;

[AttributeUsage(
    AttributeTargets.Method
)]
public sealed class ProducesOkResponseTypeAttribute :
    ProducesResponseTypeAttribute
{
    public ProducesOkResponseTypeAttribute() :
        base(
            HttpResponseCodeConstants.Success
        ) { }

    public ProducesOkResponseTypeAttribute(
        Type type
    ) : base(
        type,
        HttpResponseCodeConstants.Success
    ) { }
}