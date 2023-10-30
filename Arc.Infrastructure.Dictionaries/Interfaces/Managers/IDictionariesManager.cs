using Arc.Infrastructure.Dictionaries.Interfaces.Base;

namespace Arc.Infrastructure.Dictionaries.Interfaces.Managers;

public interface IDictionariesManager
{
    void Register(
        IDictionaryBase item
    );

    void Update();

    void Update(
        Type dependencyType
    );
}