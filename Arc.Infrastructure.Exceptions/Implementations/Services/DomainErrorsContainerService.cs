using Arc.Infrastructure.Common.Constants;
using Arc.Infrastructure.Exceptions.Interfaces.Services;
using Arc.Infrastructure.Exceptions.Models;

namespace Arc.Infrastructure.Exceptions.Implementations.Services;

public sealed class DomainErrorsContainerService :
    IDomainErrorsContainerService
{
    public ErrorsContainerModel GetErrorsContainer(
        Exception exception,
        string traceId
    )
    {
        var errors =
            GetErrors(
                exception
            );

        return
            new(
                traceId,
                errors
            );
    }

    private static ErrorModel GetErrors(
        Exception exception
    )
    {
        switch (exception)
        {
            case ServerException internalException:
            {
                var errorDetails =
                    internalException.ExceptionInfo;

                return
                    new(
                        errorDetails.Code,
                        "Business logic error",
                        errorDetails.Details
                    );
            }
            default:
            {
                return
                    new(
                        ErrorCodeConstants.ServerError,
                        "Unexpected server error",
                        string.Empty
                    );
            }
        }
    }
}