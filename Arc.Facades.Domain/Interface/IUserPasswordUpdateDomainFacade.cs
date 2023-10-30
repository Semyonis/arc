using Arc.Facades.Domain.Args;

namespace Arc.Facades.Domain.Interface;

public interface IUserPasswordUpdateDomainFacade
{
    Task ChangePassword(
        UserPasswordUpdateDomainFacadeArgs args
    );
}