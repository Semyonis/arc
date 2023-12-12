using Arc.Models.Views.Anonymous.Models;

namespace Arc.Validators.Anonymous.Implementations;

public sealed class RefreshTokenRequestValidation :
    AbstractValidator<RefreshTokenRequest>
{
    public RefreshTokenRequestValidation()
    {
        RuleFor(
                entity =>
                    entity.TokenRefresh
            )
            .NotEmpty();
    }
}