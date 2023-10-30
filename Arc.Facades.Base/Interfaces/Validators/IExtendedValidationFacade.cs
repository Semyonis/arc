namespace Arc.Facades.Base.Interfaces.Validators;

public interface IExtendedValidationFacade
<
    in TRequest,
    in TIdentity
>
    where TIdentity : BaseIdentity
{
    Task Validate(
        TRequest request,
        TIdentity identity
    );
}