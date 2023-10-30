using Arc.Facades.Admins.Interfaces.Backdoors;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Dictionaries.Interfaces.Managers;
using Arc.Models.BusinessLogic.Models.Identities;
using Arc.Models.BusinessLogic.Response;

namespace Arc.Facades.Admins.Implementations.Backdoors;

public sealed class DictionaryUpdateFacade :
    IDictionaryUpdateFacade
{
    public Task<Response> Execute(
        AdminIdentity identity
    )
    {
        _dictionariesManager
            .Update();

        var response =
            _internalFacade
                .CreateOkResponse();

        return
            Task
                .FromResult(
                    response
                );
    }

#region Constructor

    private readonly IDictionariesManager
        _dictionariesManager;

    private readonly IResponsesDomainFacade
        _internalFacade;

    public DictionaryUpdateFacade(
        IDictionariesManager
            dictionariesManager,
        IResponsesDomainFacade
            internalFacade
    )
    {
        _dictionariesManager =
            dictionariesManager;

        _internalFacade =
            internalFacade;
    }

#endregion
}