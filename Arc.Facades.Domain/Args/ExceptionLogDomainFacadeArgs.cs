namespace Arc.Facades.Domain.Args;

public sealed record ExceptionLogDomainFacadeArgs(
    Exception Exception,
    IDictionary<string, object> ErrorData
);