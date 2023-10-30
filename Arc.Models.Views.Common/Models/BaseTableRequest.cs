namespace Arc.Models.Views.Common.Models;

public abstract record BaseTableRequest<TItemDto>
{
    public required IReadOnlyList<TItemDto>
        Items { get; init; }
}