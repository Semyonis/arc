using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Arc.Executable.WebApi.Configuration.Models;

public sealed class CustomEmailConfirmationTokenProvider<TUser>(
        IDataProtectionProvider dataProtectionProvider,
        IOptions<EmailConfirmationTokenProviderOptions> options,
        ILogger<CustomEmailConfirmationTokenProvider<TUser>> logger
    )
    :
        DataProtectorTokenProvider<TUser>(
            dataProtectionProvider,
            options,
            logger
        )
    where TUser : class;