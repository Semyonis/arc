using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Arc.Executable.WebApi.Configuration.Models;

public sealed class CustomEmailConfirmationTokenProvider<TUser> :
    DataProtectorTokenProvider<TUser>
    where TUser : class
{
    public CustomEmailConfirmationTokenProvider(
        IDataProtectionProvider dataProtectionProvider,
        IOptions<EmailConfirmationTokenProviderOptions> options,
        ILogger<CustomEmailConfirmationTokenProvider<TUser>> logger
    ) : base(
        dataProtectionProvider,
        options,
        logger
    ) { }
}