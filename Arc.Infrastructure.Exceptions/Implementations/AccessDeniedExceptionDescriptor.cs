using Arc.Infrastructure.Common.Constants;
using Arc.Infrastructure.Exceptions.Implementations.Base;
using Arc.Infrastructure.Exceptions.Interfaces;

namespace Arc.Infrastructure.Exceptions.Implementations;

public sealed class AccessDeniedExceptionDescriptor :
    ExceptionDescriptorBase,
    IAccessDeniedExceptionDescriptor
{
    protected override string ErrorCode =>
        ErrorCodeConstants.AccessDenied;

    protected override int ResponseCode =>
        HttpResponseCodeConstants.AccessDenied;
}