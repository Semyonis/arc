using Arc.Database.Definitions.Implementations;

using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Arc.Database.Context;

public sealed class ArcDatabaseContext :
    IdentityDbContext<IdentityUser>,
    IDataProtectionKeyContext
{
    public ArcDatabaseContext() { }

    public ArcDatabaseContext(
        DbContextOptions options
    ) : base(
        options
    ) { }

    public DbSet<DataProtectionKey> DataProtectionKeys { get; init; } = null!;

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder
    )
    {
        base.OnConfiguring(
            optionsBuilder
        );

        optionsBuilder
            .UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(
        ModelBuilder builder
    )
    {
        base
            .OnModelCreating(
                builder
            );

        builder
            .ApplyConfigurationsFromAssembly(
                typeof(ActorDefinition).Assembly
            );

        //aren't handeled by ApplyConfigurationsFromAssembly
        builder
            .Entity<IdentityUser>()
            .ToTable(
                "asp_net_user"
            );

        builder
            .Entity<IdentityUserToken<string>>()
            .ToTable(
                "asp_net_user_token"
            );

        builder
            .Entity<IdentityUserLogin<string>>()
            .ToTable(
                "asp_net_user_login"
            );

        builder
            .Entity<IdentityUserClaim<string>>()
            .ToTable(
                "asp_net_user_claim"
            );

        builder
            .Entity<IdentityRole>()
            .ToTable(
                "asp_net_role"
            );

        builder
            .Entity<IdentityUserRole<string>>()
            .ToTable(
                "asp_net_user_role"
            );

        builder
            .Entity<IdentityRoleClaim<string>>()
            .ToTable(
                "asp_net_role_claim"
            );
    }
}