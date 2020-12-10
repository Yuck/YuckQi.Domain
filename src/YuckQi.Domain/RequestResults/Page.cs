using System.Collections.Generic;
using YuckQi.Domain.Entities.Abstract;

namespace YuckQi.Domain.RequestResults
{
    public class Page<TEntity, TKey> where TEntity : class, IEntity<TKey> where TKey : struct
    {
        #region Properties

        public IReadOnlyCollection<TEntity> Items { get; }
        public int PageNumber { get; }
        public int PageSize { get; }
        public int TotalCount { get; }

        #endregion


        #region Constructors

        public Page(IReadOnlyCollection<TEntity> items, int page, int rows, int total)
        {
            Items = items ?? new List<TEntity>();
            PageNumber = page;
            PageSize = rows;
            TotalCount = total;
        }

        #endregion
    }
}