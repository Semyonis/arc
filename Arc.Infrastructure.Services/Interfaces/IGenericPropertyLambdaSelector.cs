namespace Arc.Infrastructure.Services.Interfaces;

public interface IGenericPropertyLambdaSelector
{
    dynamic GetLambda<TEntity>(
        string propertyName
    );
}