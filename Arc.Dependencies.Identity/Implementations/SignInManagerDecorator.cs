namespace Arc.Dependencies.Identity.Implementations;

public sealed class SignInManagerDecorator :
    ISignInManagerDecorator
{
    public async Task<SignInResult> PasswordSignIn(
        string name,
        string password
    ) =>
        await
            _signInManager
                .PasswordSignInAsync(
                    name,
                    password,
                    true,
                    false
                );

#region Constructor

    private readonly SignInManager<IdentityUser>
        _signInManager;

    public SignInManagerDecorator(
        SignInManager<IdentityUser>
            signInManager
    ) =>
        _signInManager =
            signInManager;

#endregion
}