using Arc.Infrastructure.Exceptions.Implementations.Base;
using Arc.Infrastructure.Exceptions.Interfaces;

using static Arc.Infrastructure.Common.Constants.ErrorCodeConstants;
using static Arc.Infrastructure.Common.Constants.HttpResponseCodeConstants;

namespace Arc.Infrastructure.Exceptions.Implementations;

public sealed class InterfaceNotImplementedExceptionDescriptor :
    ExceptionDescriptorBase,
    IInterfaceNotImplementedExceptionDescriptor
{
    protected override string ErrorCode =>
        InterfaceNotImplemented;

    protected override int ResponseCode =>
        BadRequest;
}