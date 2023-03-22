using System;
using System.Collections.Generic;

namespace YuckQi.Domain.ValueObjects.Abstract;

public interface IPage
{
    Int32 PageNumber { get; }
    Int32 PageSize { get; }
}

public interface IPage<out T> : IPage
{
    IReadOnlyCollection<T> Items { get; }
    Int32 TotalCount { get; }
}
