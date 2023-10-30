using Arc.Facades.Domain.Args;

namespace Arc.Facades.Domain.Interface;

public interface IUserCreateDomainFacade
{
    Task Create(
        CreateUserDomainFacadeArgs args
    );
}