using System.Collections.Generic;
using YuckQi.Domain.Application.Abstract;
using YuckQi.Domain.Entities.Abstract;

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

    public class Page<TEntity, TKey> : Page where TEntity : class, IEntity<TKey> where TKey : struct
    {
        #region Properties

        public IReadOnlyCollection<TEntity> Items { get; }
        public int TotalCount { get; }

        #endregion


        #region Constructors

        public Page(IReadOnlyCollection<TEntity> items, int total, int number, int size) : base(number, size)
        {
            Items = items ?? new List<TEntity>();
            TotalCount = total;
        }

        #endregion
    }
}