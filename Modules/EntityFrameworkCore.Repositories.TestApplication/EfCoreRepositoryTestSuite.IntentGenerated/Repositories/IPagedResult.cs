using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.Repositories.Api.PagedResultInterface", Version = "1.0")]

namespace EfCoreRepositoryTestSuite.IntentGenerated.Repositories
{
    /// <summary>
    /// Instead of retrieving the entire collection of elements from
    /// a persistence store, a single <see cref="IPagedResult{T}"/> is returned
    /// representing a single "page" of elements. Supplying a different <b>PageNo</b>
    /// will return a different "page" of elements. 
    /// </summary>
    /// <typeparam name="T">Type of elements</typeparam>
    public interface IPagedResult<out T> : IEnumerable<T>
    {
        int TotalCount { get; }
        int PageCount { get; }
        int PageNo { get; }
        int PageSize { get; }
    }
}
