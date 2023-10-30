using Arc.Facades.Domain.Args;

namespace Arc.Facades.Domain.Interface;

public interface IUserUpdateDomainFacade
{
    Task Update(
        UserUpdateDomainFacadeArgs args
    );
}