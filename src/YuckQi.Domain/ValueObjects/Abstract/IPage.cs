using System.Collections.Generic;

namespace YuckQi.Domain.ValueObjects.Abstract
{
    public interface IPage
    {
        int PageNumber { get; }
        int PageSize { get; }
    }

    public interface IPage<out T> : IPage
    {
        IReadOnlyCollection<T> Items { get; }
        int TotalCount { get; }
    }
}