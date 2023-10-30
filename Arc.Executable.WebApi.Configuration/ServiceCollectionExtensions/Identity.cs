using Arc.Database.Context;
using Arc.Executable.WebApi.Configuration.Models;

using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;

namespace Arc.Executable.WebApi.Configuration.ServiceCollectionExtensions;

public static class Identity
{
    public static IServiceCollection SetupIdentity(
        this IServiceCollection services
    )
    {
        services
            .AddIdentity<IdentityUser, IdentityRole>(
                SetupUpOptions()
            )
            .AddRoleManager<RoleManager<IdentityRole>>()
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<ArcDatabaseContext>()
            .AddRoles<IdentityRole>();

        services
            .AddDataProtection()
            .PersistKeysToDbContext<ArcDatabaseContext>();

        return
            services
                .AddTransient<CustomEmailConfirmationTokenProvider<IdentityUser>>();
    }

    private static Action<IdentityOptions> SetupUpOptions() =>
        option =>
        {
            option.Password.RequireDigit = false;
            option.Password.RequireUppercase = false;
            option.Password.RequireLowercase = false;
            option.Password.RequireNonAlphanumeric = false;

            option.Tokens.ProviderMap.Add(
                "CustomEmailConfirmation",
                new(
                    typeof(CustomEmailConfirmationTokenProvider<IdentityUser>)
                )
            );

            option.Tokens.EmailConfirmationTokenProvider =
                "CustomEmailConfirmation";
        };
}