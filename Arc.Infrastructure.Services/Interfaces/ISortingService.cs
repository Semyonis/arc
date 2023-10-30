using System.Collections.Generic;

using Arc.Infrastructure.Common.Interfaces;
using Arc.Infrastructure.Common.Models;

namespace Arc.Infrastructure.Services.Interfaces;

public interface ISortingService
{
    ResultContainer<IReadOnlyList<T>> SortByList<T>(
        IReadOnlyList<T> source,
        IReadOnlyList<int> target
    )
        where T : IWithIdentifier;
}