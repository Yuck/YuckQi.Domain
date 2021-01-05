using System.Collections.Generic;
using YuckQi.Domain.ValueObjects.Abstract;

namespace YuckQi.Domain.ValueObjects
{
    public readonly struct Page : IPage
    {
        #region Properties

        public int PageNumber { get; }
        public int PageSize { get; }

        #endregion


        #region Constructors

        public Page(int page, int size)
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
        public int PageNumber { get; }
        public int PageSize { get; }
        public int TotalCount { get; }

        #endregion


        #region Constructors

        public Page(IReadOnlyCollection<T> items, int total, int page, int size)
        {
            Items = items ?? new List<T>();
            PageNumber = page;
            PageSize = size;
            TotalCount = total;
        }

        #endregion
    }
}