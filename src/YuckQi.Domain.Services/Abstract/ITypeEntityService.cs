using System.Threading.Tasks;
using YuckQi.Domain.Entities.Types.Abstract;
using YuckQi.Domain.Services.Models;
using YuckQi.Domain.Validation;
using YuckQi.Domain.ValueObjects;

namespace YuckQi.Domain.Services.Abstract
{
    public interface ITypeEntityService<T, in TKey> where T : TypeEntityBase<TKey> where TKey : struct
    {
        Task<Result<T>> CreateAsync(T entity);
        Task<Result<T>> GetAsync(TKey key);
        Task<Result<T>> ModifyAsync(T entity);
        Task<Result<Page<T>>> SearchAsync(TypeSearchCriteria criteria = null);
    }
}