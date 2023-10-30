using static Arc.Infrastructure.Entity.Expressions.Extensions.Implementations.ItemsSimplePropertiesExpressions;

namespace Arc.Database.Definitions.Implementations;

public sealed class ItemsSimplePropertiesDefinition :
    IEntityTypeConfiguration<ItemsSimpleProperties>
{
    public void Configure(
        EntityTypeBuilder<ItemsSimpleProperties> builder
    )
    {
        builder
            .SetProperty(
                GetId(),
                Integer
            );

        builder
            .SetRequiredProperty(
                GetSimplePropertyId(),
                Integer
            );

        builder
            .SetRequiredProperty(
                GetItemId(),
                Integer
            );

        builder
            .SetKey(
                GetId()
            );

        builder
            .SetIndex(
                GetItemId()
            );

        builder
            .SetIndex(
                GetSimplePropertyId()
            );

        builder
            .SetUniqueIndex(
                entity =>
                    new
                    {
                        entity.ItemId,
                        entity.SimplePropertyId,
                    }
            );

        builder
            .SetOneToManyNavigation(
                GetSimpleProperty(),
                SimplePropertyExpressions.GetItemLinks(),
                GetSimplePropertyId()
            );

        builder
            .SetOneToManyNavigation(
                GetItem(),
                ItemExpressions.GetSimplePropertyLinks(),
                GetItemId()
            );
    }
}