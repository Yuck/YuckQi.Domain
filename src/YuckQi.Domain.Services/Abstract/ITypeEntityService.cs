using System;
using System.Threading.Tasks;
using YuckQi.Domain.Aspects.Abstract;
using YuckQi.Domain.Services.Models;
using YuckQi.Domain.Validation;
using YuckQi.Domain.ValueObjects.Abstract;

namespace YuckQi.Domain.Services.Abstract
{
    public interface ITypeEntityService<TTypeEntity, in TKey> where TTypeEntity : IType
    {
        Task<Result<TTypeEntity>> CreateAsync(TTypeEntity entity);
        Task<Result<TTypeEntity>> GetAsync(Guid identifier);
        Task<Result<TTypeEntity>> GetAsync(TKey key);
        Task<Result<TTypeEntity>> ModifyAsync(TTypeEntity entity);
        Task<Result<IPage<TTypeEntity>>> SearchAsync(TypeSearchCriteria criteria = null);
    }
}