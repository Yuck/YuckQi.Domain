using System.Collections.Generic;
using YuckQi.Domain.Application.Abstract;

namespace YuckQi.Domain.Application.Queries.Results
{
    public class Page : IPage
    {
        #region Properties

        public int PageNumber { get; }
        public int PageSize { get; }

        #endregion


        #region Constructors

        public Page(int number, int size)
        {
            PageNumber = number;
            PageSize = size;
        }

        #endregion
    }

    public class Page<T> : Page where T : class
    {
        #region Properties

        public IReadOnlyCollection<T> Items { get; }
        public int TotalCount { get; }

        #endregion


        #region Constructors

        public Page(IReadOnlyCollection<T> items, int total, int number, int size) : base(number, size)
        {
            Items = items ?? new List<T>();
            TotalCount = total;
        }

        #endregion
    }
}