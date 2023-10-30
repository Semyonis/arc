using Arc.Facades.Domain.Args;

namespace Arc.Facades.Domain.Interface;

public interface IAdminCreateDomainFacade
{
    Task<int> Create(
        AdminCreateDomainFacadeArgs request
    );
}