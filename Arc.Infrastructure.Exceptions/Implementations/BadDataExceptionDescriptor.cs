using Arc.Infrastructure.Exceptions.Implementations.Base;
using Arc.Infrastructure.Exceptions.Interfaces;

using static Arc.Infrastructure.Common.Constants.ErrorCodeConstants;
using static Arc.Infrastructure.Common.Constants.HttpResponseCodeConstants;

namespace Arc.Infrastructure.Exceptions.Implementations;

public sealed class BadDataExceptionDescriptor :
    ExceptionDescriptorBase,
    IBadDataExceptionDescriptor
{
    protected override string ErrorCode =>
        BadData;

    protected override int ResponseCode =>
        BadRequest;
}