using Arc.Infrastructure.Common.Constants;

namespace Arc.Infrastructure.Exceptions.Models;

public sealed class ServerException(
        ExceptionInfo exceptionInfo,
        int responseCode =
            HttpResponseCodeConstants.BadRequest
    )
    :
        ApplicationException
{
    public int ResponseCode { get; } = responseCode;

    public ExceptionInfo ExceptionInfo { get; } = exceptionInfo;
}