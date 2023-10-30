using Arc.Infrastructure.Exceptions.Models;

namespace Arc.Infrastructure.Exceptions.Interfaces.Services;

public interface IDomainErrorsContainerService
{
    ErrorsContainerModel GetErrorsContainer(
        Exception exception,
        string traceId
    );
}