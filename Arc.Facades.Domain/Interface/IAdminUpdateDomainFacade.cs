using Arc.Facades.Domain.Args;

namespace Arc.Facades.Domain.Interface;

public interface IAdminUpdateDomainFacade
{
    Task Update(
        AdminUpdateDomainFacadeArgs args
    );
}