using static Arc.Infrastructure.Common.Constants.Database.DatabaseSpecialValueConstants;
using static Arc.Infrastructure.Entity.Expressions.Extensions.Implementations.ItemExpressions;

namespace Arc.Database.Definitions.Implementations;

public sealed class ItemDefinition :
    IEntityTypeConfiguration<Item>
{
    public void Configure(
        EntityTypeBuilder<Item> builder
    )
    {
        builder
            .SetProperty(
                GetId(),
                Integer
            );

        builder
            .SetRequiredProperty(
                GetDateCreated(),
                Timestamp
            )
            .HasDefaultValueSql(
                CurrentTimestamp
            );

        builder
            .SetRequiredProperty(
                GetName(),
                String128
            );

        builder
            .SetKey(
                GetId()
            );

        builder
            .SetIndex(
                GetName()
            );
    }
}