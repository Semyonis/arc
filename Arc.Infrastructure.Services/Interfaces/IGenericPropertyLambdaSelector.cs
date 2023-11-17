using Arc.Infrastructure.Common.Models;

namespace Arc.Infrastructure.Services.Interfaces;

public interface IGenericPropertyLambdaSelector
{
    ResultContainer<dynamic> GetLambda<TEntity>(
        string propertyName
    );
}