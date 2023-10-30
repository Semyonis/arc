namespace Arc.Facades.Domain.Interface;

public interface IUserDeleteDomainFacade
{
    Task Delete(
        int userId
    );
}