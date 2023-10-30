namespace Arc.Facades.Base.Interfaces.Validators;

public interface IValidationFacade<in TIdentity>
    where TIdentity : BaseIdentity
{
    Task Validate(
        TIdentity identity
    );
}