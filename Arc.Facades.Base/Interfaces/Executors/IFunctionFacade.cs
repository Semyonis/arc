namespace Arc.Facades.Base.Interfaces.Executors;

public interface IFunctionFacade<in TRequest>
{
    Task<Response> Execute(
        TRequest request
    );
}