using Arc.Infrastructure.Exceptions.Implementations.Base;
using Arc.Infrastructure.Exceptions.Interfaces;

using static Arc.Infrastructure.Common.Constants.ErrorCodeConstants;
using static Arc.Infrastructure.Common.Constants.HttpResponseCodeConstants;

namespace Arc.Infrastructure.Exceptions.Implementations;

public sealed class UserNotFoundExceptionDescriptor :
    ExceptionDescriptorBase,
    IUserNotFoundExceptionDescriptor
{
    protected override string ErrorCode =>
        UserNotFound;

    protected override int ResponseCode =>
        BadRequest;
}