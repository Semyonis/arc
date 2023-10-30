using System;
using System.Collections.Generic;

using Arc.Infrastructure.Dictionaries.Interfaces.Base;
using Arc.Infrastructure.Dictionaries.Interfaces.Managers;

namespace Arc.Tests.Integrations.Models.Managers;

public sealed class DictionariesManager :
    IDictionariesManager
{
    private readonly List<IDictionaryBase>
        _dictionaries =
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
        UpdateItems(
            _dictionaries
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