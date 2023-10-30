using Arc.Infrastructure.Common.Constants;
using Arc.Infrastructure.Exceptions.Implementations.Base;
using Arc.Infrastructure.Exceptions.Interfaces;

namespace Arc.Infrastructure.Exceptions.Implementations;

public sealed class ServiceUnavailableExceptionDescriptor :
    ExceptionDescriptorBase,
    IServiceUnavailableExceptionDescriptor
{
    protected override string ErrorCode =>
        ErrorCodeConstants.ServiceUnavailable;

    protected override int ResponseCode =>
        HttpResponseCodeConstants.ServiceUnavailable;
}