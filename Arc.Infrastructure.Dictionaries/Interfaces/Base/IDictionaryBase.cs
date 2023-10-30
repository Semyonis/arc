namespace Arc.Infrastructure.Dictionaries.Interfaces.Base;

public interface IDictionaryBase
{
    bool IsLoaded();

    void Clear();

    bool IsDependentFrom(
        Type dependencyType
    );
}