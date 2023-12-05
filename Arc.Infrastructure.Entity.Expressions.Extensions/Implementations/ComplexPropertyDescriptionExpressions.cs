using Arc.Database.Entities.Models;

namespace Arc.Infrastructure.Entity.Expressions.Extensions.Implementations;

public static class ComplexPropertyDescriptionExpressions
{
    public static Expression<Func<ComplexPropertyDescription, int>> GetId() =>
        entity =>
            entity.Id;

    public static Expression<Func<ComplexPropertyDescription, int>> GetComplexPropertyId() =>
        entity =>
            entity.ComplexPropertyId;

    public static Expression<Func<ComplexPropertyDescription, string>> GetValue() =>
        entity =>
            entity.Value;

    public static Expression<Func<ComplexPropertyDescription, ComplexProperty>> GetComplexProperty() =>
        entity =>
            entity.ComplexProperty;
}