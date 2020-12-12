using System.Threading.Tasks;
using YuckQi.Domain.Application.Queries.Results;
using YuckQi.Domain.Entities.Types;
using YuckQi.Domain.Services.Models;
using YuckQi.Domain.Validation;

namespace YuckQi.Domain.Services.Abstract
{
    public interface ITypeEntityService<T, TKey> where T : TypeEntityBase<TKey> where TKey : struct
    {
        Task<Result<Page<T, TKey>>> SearchAsync(TypeSearchCriteria criteria = null);
    }
}