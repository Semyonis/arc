using Arc.Models.BusinessLogic.Response;

namespace Arc.Infrastructure.Exceptions.Models;

public sealed record ErrorsContainerModel(
    string TraceId,
    ErrorModel Error
) : Response;