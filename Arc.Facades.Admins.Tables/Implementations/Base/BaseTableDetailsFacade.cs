using Arc.Converters.Base.Interfaces;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Common.Interfaces;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Infrastructure.Repositories.Read.Interfaces.Base;
using Arc.Models.BusinessLogic.Models.Identities;
using Arc.Models.BusinessLogic.Response;

using Microsoft.EntityFrameworkCore.Query;

namespace Arc.Facades.Admins.Tables.Implementations.Base;

public abstract class BaseTableDetailsFacade
<
    TEntity,
    TReadEntityResponse
>
    where TEntity : class, IWithIdentifier
{
    public async Task<Response> Execute(
        int entityId,
        AdminIdentity identity
    )
    {
        var includes =
            GetInclude();

        var entity =
            await
                _readRepository
                    .GetById(
                        entityId,
                        includes
                    );

        if (entity == default)
        {
            throw
                _entityNotFoundExceptionDescriptor
                    .CreateException(
                        typeof(TEntity).Name
                    );
        }

        var response =
            _readConverter
                .Convert(
                    entity
                );

        return
            _internalFacade
                .CreateOkResponse(
                    response
                );
    }

    protected virtual Func
    <
        IQueryable<TEntity>,
        IIncludableQueryable<TEntity, object>
    >? GetInclude() => default;

#region Constructor

    private readonly IConverterBase<TEntity, TReadEntityResponse>
        _readConverter;

    private readonly IResponsesDomainFacade
        _internalFacade;

    private readonly IReadRepositoryBase<TEntity>
        _readRepository;

    private readonly IEntityNotFoundExceptionDescriptor
        _entityNotFoundExceptionDescriptor;

    protected BaseTableDetailsFacade(
        IReadRepositoryBase<TEntity>
            readRepository,
        IResponsesDomainFacade
            internalFacade,
        IConverterBase<TEntity, TReadEntityResponse>
            readConverter,
        IEntityNotFoundExceptionDescriptor
            entityNotFoundExceptionDescriptor
    )
    {
        _readRepository =
            readRepository;

        _internalFacade =
            internalFacade;

        _readConverter =
            readConverter;

        _entityNotFoundExceptionDescriptor =
            entityNotFoundExceptionDescriptor;
    }

#endregion
}