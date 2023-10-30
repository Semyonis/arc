using Arc.Infrastructure.Exceptions.Models;

namespace Arc.Infrastructure.Exceptions.Interfaces.Base;

public interface IExceptionDescriptorBase
{
    ServerException CreateException(
        object? details =
            default
    );
}