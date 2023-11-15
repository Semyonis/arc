namespace Arc.Facades.Base.Interfaces.Methods;

public interface IExtendedMethodFacade<in TIdentity>
    where TIdentity : BaseIdentity
{
    Task<Response> Execute(
        TIdentity identity
    );
}