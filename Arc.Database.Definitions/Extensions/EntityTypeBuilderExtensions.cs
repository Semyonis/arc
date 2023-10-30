namespace Arc.Database.Definitions.Extensions;

public static class EntityTypeBuilderExtensions
{
    public static KeyBuilder SetKey
    <
        TEntity,
        TProperty
    >(
        this EntityTypeBuilder<TEntity> builder,
        Expression
        <
            Func<TEntity,
                TProperty>
        > propertyExpression
    )
        where TEntity : class
    {
        var memberAccessList =
            propertyExpression.GetMemberAccessList();

        var memberNamesArray =
            memberAccessList
                .Select(
                    member =>
                        member.Name
                )
                .ToArray();

        return
            builder
                .HasKey(
                    memberNamesArray
                );
    }

    public static IndexBuilder<TEntity> SetIndex
    <
        TEntity,
        TProperty
    >(
        this EntityTypeBuilder<TEntity> builder,
        Expression
        <
            Func<TEntity,
                TProperty>
        > propertyExpression
    )
        where TEntity : class
    {
        var memberAccessList =
            propertyExpression.GetMemberAccessList();

        var memberNamesArray =
            memberAccessList
                .Select(
                    member =>
                        member.Name
                )
                .ToArray();

        return
            builder
                .HasIndex(
                    memberNamesArray
                );
    }

    public static IndexBuilder<TEntity> SetUniqueIndex
    <
        TEntity,
        TProperty
    >(
        this EntityTypeBuilder<TEntity> builder,
        Expression
        <
            Func<TEntity,
                TProperty>
        > propertyExpression
    )
        where TEntity : class =>
        SetIndex(
                builder,
                propertyExpression
            )
            .IsUnique();

    public static ReferenceReferenceBuilder<TEntity, TProperty> SetOneToOneNavigation
    <
        TEntity,
        TProperty,
        TKey
    >(
        this EntityTypeBuilder<TEntity> builder,
        Expression
        <
            Func
            <
                TEntity,
                TProperty
            >
        > navigationPropertyExpression,
        Expression
        <
            Func
            <
                TProperty,
                TEntity
            >
        > navigationBackPropertyExpression,
        Expression
        <
            Func
            <
                TEntity,
                TKey
            >
        > keyPropertyExpression
    )
        where TEntity : class
        where TProperty : class
    {
        var navigationBackMemberAccessList =
            navigationBackPropertyExpression.GetMemberAccessList();

        var navigationBackMemberName =
            navigationBackMemberAccessList
                .Select(
                    member =>
                        member.Name
                )
                .FirstOrDefault();

        var keyMemberAccessList =
            keyPropertyExpression.GetMemberAccessList();

        var keyName =
            keyMemberAccessList
                .Select(
                    member =>
                        member.Name
                )
                .First();

        return
            builder
                .HasOne(
                    navigationPropertyExpression!
                )
                .WithOne(
                    navigationBackMemberName
                )
                .HasForeignKey<TEntity>(
                    keyName
                );
    }

    public static ReferenceCollectionBuilder<TProperty, TEntity> SetOneToManyNavigation
    <
        TEntity,
        TProperty,
        TKey
    >(
        this EntityTypeBuilder<TEntity> builder,
        Expression
        <
            Func
            <
                TEntity,
                TProperty
            >
        > navigationPropertyExpression,
        Expression
        <
            Func
            <
                TProperty,
                ICollection<TEntity>
            >
        > navigationBackPropertyExpression,
        Expression
        <
            Func
            <
                TEntity,
                TKey
            >
        > keyPropertyExpression
    )
        where TEntity : class
        where TProperty : class
    {
        var navigationBackMemberAccessList =
            navigationBackPropertyExpression.GetMemberAccessList();

        var navigationBackMemberName =
            navigationBackMemberAccessList
                .Select(
                    member =>
                        member.Name
                )
                .FirstOrDefault();

        var keyMemberAccessList =
            keyPropertyExpression.GetMemberAccessList();

        var keyName =
            keyMemberAccessList
                .Select(
                    member =>
                        member.Name
                )
                .First();

        return
            builder
                .HasOne(
                    navigationPropertyExpression!
                )
                .WithMany(
                    navigationBackMemberName
                )
                .HasForeignKey(
                    keyName
                );
    }

    public static PropertyBuilder<TProperty> SetProperty
    <
        TEntity,
        TProperty
    >(
        this EntityTypeBuilder<TEntity> builder,
        Expression
        <
            Func<TEntity,
                TProperty>
        > propertyExpression,
        string columnType
    )
        where TEntity : class =>
        builder
            .Property(
                propertyExpression
            )
            .HasColumnType(
                columnType
            );

    public static PropertyBuilder<TProperty> SetRequiredProperty
    <
        TEntity,
        TProperty
    >(
        this EntityTypeBuilder<TEntity> builder,
        Expression
        <
            Func<TEntity,
                TProperty>
        > propertyExpression,
        string columnType
    )
        where TEntity : class =>
        SetProperty(
                builder,
                propertyExpression,
                columnType
            )
            .IsRequired();
}