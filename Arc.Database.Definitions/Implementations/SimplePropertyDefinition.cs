using static Arc.Infrastructure.Entity.Expressions.Extensions.Implementations.SimplePropertyExpressions;

namespace Arc.Database.Definitions.Implementations;

public sealed class SimplePropertyDefinition :
    IEntityTypeConfiguration<SimpleProperty>
{
    public void Configure(
        EntityTypeBuilder<SimpleProperty> builder
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

        builder
            .SetUniqueIndex(
                GetValue()
            );
    }
}