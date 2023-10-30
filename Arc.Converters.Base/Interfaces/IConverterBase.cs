namespace Arc.Converters.Base.Interfaces;

public interface IConverterBase
<
    in TInput,
    out TOutput
>
{
    TOutput Convert(
        TInput entity
    );

    IReadOnlyList<TOutput> Convert(
        IEnumerable<TInput> entity
    );
}