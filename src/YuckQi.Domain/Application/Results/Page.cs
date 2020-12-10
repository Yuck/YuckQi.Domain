using System.Collections.Generic;
using YuckQi.Domain.Application.Abstract;
using YuckQi.Domain.Entities.Abstract;

namespace YuckQi.Domain.Application.Results
{
    public class Page<TEntity, TKey> : IPage where TEntity : class, IEntity<TKey> where TKey : struct
    {
        #region Properties

        public IReadOnlyCollection<TEntity> Items { get; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
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