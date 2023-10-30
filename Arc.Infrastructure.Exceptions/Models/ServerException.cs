using Arc.Infrastructure.Common.Constants;

namespace Arc.Infrastructure.Exceptions.Models;

public sealed class ServerException :
    ApplicationException
{
    public ServerException(
        ExceptionInfo exceptionInfo,
        int responseCode =
            HttpResponseCodeConstants.BadRequest
    )
    {
        ResponseCode =
            responseCode;

        ExceptionInfo =
            exceptionInfo;
    }

    public int ResponseCode { get; }

    public ExceptionInfo ExceptionInfo { get; }
}