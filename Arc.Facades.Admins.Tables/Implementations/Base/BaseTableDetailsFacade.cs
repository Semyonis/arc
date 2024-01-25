using Arc.Converters.Base.Interfaces;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Common.Interfaces;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Infrastructure.Repositories.Read.Interfaces.Base;
using Arc.Models.BusinessLogic.Models;
using Arc.Models.BusinessLogic.Response;

using Microsoft.EntityFrameworkCore.Query;

namespace Arc.Facades.Admins.Tables.Implementations.Base;

public abstract class BaseTableDetailsFacade
<
    TEntity,
    TReadEntityResponse
>(
    IReadRepositoryBase<TEntity>
        readRepository,
    IResponsesDomainFacade
        internalFacade,
    IConverterBase<TEntity, TReadEntityResponse>
        readConverter,
    IEntityNotFoundExceptionDescriptor
        entityNotFoundExceptionDescriptor
)
    where TEntity : class, IWithIdentifier
{
    public async Task<Response> Execute(
        int entityId,
        ArcIdentity identity
    )
    {
        var includes =
            GetInclude();

        var entity =
            await
                readRepository
                    .GetById(
                        entityId,
                        includes
                    );

        if (entity == default)
        {
            throw
                entityNotFoundExceptionDescriptor
                    .CreateException(
                        typeof(TEntity).Name
                    );
        }

        var response =
            readConverter
                .Convert(
                    entity
                );

        return
            internalFacade
                .CreateOkResponse(
                    response
                );
    }

    protected virtual Func
    <
        IQueryable<TEntity>,
        IIncludableQueryable<TEntity, object>
    >? GetInclude() => default;
}