using Arc.Infrastructure.Common.Extensions;

namespace Arc.Converters.Base.Implementations;

public abstract class ConverterBase
<
    TEntityFrom,
    TEntityTo
>
    where TEntityFrom : class
    where TEntityTo : class
{
    [SuppressMessage(
        "ReSharper",
        "PossibleMultipleEnumeration"
    )]
    public IReadOnlyList<TEntityTo> Convert(
        IEnumerable<TEntityFrom> entities
    )
    {
        if (entities.IsEmpty())
        {
            return
                new List<TEntityTo>();
        }

        return
            entities
                .Select(
                    Convert
                )
                .ToList();
    }

    public abstract TEntityTo Convert(
        TEntityFrom entity
    );
}