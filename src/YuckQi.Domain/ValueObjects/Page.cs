using System;
using System.Collections.Generic;
using YuckQi.Domain.ValueObjects.Abstract;

namespace YuckQi.Domain.ValueObjects;

public readonly struct Page : IPage
{
    #region Properties

    public Int32 PageNumber { get; }
    public Int32 PageSize { get; }

    #endregion


    #region Constructors

    public Page(Int32 page, Int32 size)
    {
        PageNumber = page;
        PageSize = size;
    }

    #endregion
}

public readonly struct Page<T> : IPage<T>
{
    #region Properties

    public IReadOnlyCollection<T> Items { get; }
    public Int32 PageNumber { get; }
    public Int32 PageSize { get; }
    public Int32 TotalCount { get; }

    #endregion


    #region Constructors

    public Page(IReadOnlyCollection<T> items, Int32 total, Int32 page, Int32 size)
    {
        Items = items;
        PageNumber = page;
        PageSize = size;
        TotalCount = total;
    }

    #endregion
}
