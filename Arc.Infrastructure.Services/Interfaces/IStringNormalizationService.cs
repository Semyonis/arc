namespace Arc.Infrastructure.Services.Interfaces;

public interface IStringNormalizationService
{
    object Normalize(
        object value
    );
}