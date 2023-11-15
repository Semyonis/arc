namespace Arc.Facades.Base.Interfaces.Executors;

public interface IExtendedFunctionFacade
<
    in TRequest,
    in TIdentity
>
    where TIdentity : BaseIdentity
{
    Task<Response> Execute(
        TRequest request,
        TIdentity identity
    );
}