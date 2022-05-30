using System.Threading.Tasks;
using YuckQi.Domain.Aspects.Abstract;
using YuckQi.Domain.Entities.Abstract;
using YuckQi.Domain.Services.Models;
using YuckQi.Domain.Validation;
using YuckQi.Domain.ValueObjects.Abstract;

namespace YuckQi.Domain.Services.Abstract;

public interface ITypeEntityService<TTypeEntity, in TIdentifier> where TTypeEntity : IEntity<TIdentifier>, IType where TIdentifier : struct
{
    Task<Result<TTypeEntity>> CreateAsync(TTypeEntity entity);
    Task<Result<TTypeEntity>> GetAsync(TIdentifier identifier);
    Task<Result<TTypeEntity>> ModifyAsync(TTypeEntity entity);
    Task<Result<IPage<TTypeEntity>>> SearchAsync(TypeSearchCriteria criteria = null);
}
