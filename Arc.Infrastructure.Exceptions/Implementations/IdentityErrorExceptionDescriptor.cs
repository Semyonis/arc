using Arc.Infrastructure.Exceptions.Implementations.Base;
using Arc.Infrastructure.Exceptions.Interfaces;

using static Arc.Infrastructure.Common.Constants.ErrorCodeConstants;
using static Arc.Infrastructure.Common.Constants.HttpResponseCodeConstants;

namespace Arc.Infrastructure.Exceptions.Implementations;

public sealed class IdentityErrorExceptionDescriptor :
    ExceptionDescriptorBase,
    IIdentityErrorExceptionDescriptor
{
    protected override string ErrorCode =>
        IdentityError;

    protected override int ResponseCode =>
        BadRequest;
}