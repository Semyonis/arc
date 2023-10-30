using Microsoft.AspNetCore.Identity;

namespace Arc.Executable.WebApi.Configuration.Models;

public sealed class EmailConfirmationTokenProviderOptions :
    DataProtectionTokenProviderOptions
{
    public EmailConfirmationTokenProviderOptions()
    {
        Name =
            "EmailConfirmationTokenProviderOptions";

        TokenLifespan =
            TimeSpan
                .FromDays(
                    7
                );
    }
}