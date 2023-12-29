using Arc.Facades.Domain.Args;

namespace Arc.Facades.Domain.Interface;

public interface IExceptionLogDomainFacade
{
    Task Log(
        ExceptionLogDomainFacadeArgs args
    );
}