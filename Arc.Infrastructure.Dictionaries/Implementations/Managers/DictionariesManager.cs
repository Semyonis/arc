using Arc.Infrastructure.Dictionaries.Interfaces.Base;
using Arc.Infrastructure.Dictionaries.Interfaces.Managers;

namespace Arc.Infrastructure.Dictionaries.Implementations.Managers;

public sealed class DictionariesManager :
    IDictionariesManager
{
    private readonly List<IDictionaryBase> _dictionaries =
        new();

    public void Register(
        IDictionaryBase item
    )
    {
        _dictionaries
            .Add(
                item
            );
    }

    public void Update()
    {
        UpdateItems(
            _dictionaries
        );
    }

    public void Update(
        Type dependencyType
    )
    {
        var dictionaryItems =
            _dictionaries
                .Where(
                    item =>
                        item
                            .IsDependentFrom(
                                dependencyType
                            )
                );

        UpdateItems(
            dictionaryItems
        );
    }

    private static void UpdateItems(
        IEnumerable<IDictionaryBase> items
    )
    {
        foreach (var item in items)
        {
            if (item.IsLoaded())
            {
                item.Clear();
            }
        }
    }
}