using Arc.Facades.Domain.Args;

namespace Arc.Facades.Domain.Interface;

public interface IExceptionLogDomainFacade
{
    void Log(
        ExceptionLogDomainFacadeArgs args
    );
}