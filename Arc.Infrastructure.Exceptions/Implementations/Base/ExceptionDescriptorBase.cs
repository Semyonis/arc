using Arc.Infrastructure.Exceptions.Models;

namespace Arc.Infrastructure.Exceptions.Implementations.Base;

public abstract class ExceptionDescriptorBase
{
    protected abstract string ErrorCode { get; }

    protected abstract int ResponseCode { get; }

    public ServerException CreateException(
        object? details
    ) =>
        new(
            new(
                ErrorCode,
                details
            ),
            ResponseCode
        );
}