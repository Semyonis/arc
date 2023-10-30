using static Arc.Infrastructure.Entity.Expressions.Extensions.Implementations.ActorExpressions;

namespace Arc.Database.Definitions.Implementations;

public sealed class ActorDefinition :
    IEntityTypeConfiguration<Actor>
{
    public void Configure(
        EntityTypeBuilder<Actor> builder
    )
    {
        builder
            .SetProperty(
                GetId(),
                Integer
            );

        builder
            .SetRequiredProperty(
                GetEmail(),
                String256
            );

        builder
            .SetRequiredProperty(
                GetFirstName(),
                String128
            );

        builder
            .SetRequiredProperty(
                GetLastName(),
                String128
            );

        builder
            .SetRequiredProperty(
                GetDiscriminator(),
                String64
            );

        builder
            .SetKey(
                GetId()
            );

        builder
            .SetUniqueIndex(
                GetEmail()
            );
    }
}