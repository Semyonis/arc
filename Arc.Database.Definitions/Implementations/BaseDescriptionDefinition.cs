using static Arc.Infrastructure.Entity.Expressions.Extensions.Implementations.BaseDescriptionExpressions;

namespace Arc.Database.Definitions.Implementations;

public sealed class BaseDescriptionDefinition :
    IEntityTypeConfiguration<BaseDescription>
{
    public void Configure(
        EntityTypeBuilder<BaseDescription> builder
    )
    {
        builder
            .SetProperty(
                GetId(),
                Integer
            );

        builder
            .SetRequiredProperty(
                GetValue(),
                String128
            );

        builder
            .SetKey(
                GetId()
            );
    }
}