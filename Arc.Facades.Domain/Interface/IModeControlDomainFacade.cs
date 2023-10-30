using Arc.Facades.Domain.Args;

namespace Arc.Facades.Domain.Interface;

public interface IModeControlDomainFacade
{
    Task SetMode(
        ModeControlDomainFacadeArgs args
    );
}