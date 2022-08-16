using System.Threading;
using System.Threading.Tasks;
using YuckQi.Domain.Aspects.Abstract;
using YuckQi.Domain.Entities.Abstract;
using YuckQi.Domain.Services.Models;
using YuckQi.Domain.Validation;
using YuckQi.Domain.ValueObjects.Abstract;

namespace YuckQi.Domain.Services.Abstract;

public interface ITypeEntityService<TTypeEntity, in TIdentifier> where TTypeEntity : IEntity<TIdentifier>, IType where TIdentifier : struct
{
    Task<Result<TTypeEntity>> Create(TTypeEntity entity, CancellationToken cancellationToken = default);
    Task<Result<TTypeEntity>> Get(TIdentifier identifier, CancellationToken cancellationToken = default);
    Task<Result<TTypeEntity>> Modify(TTypeEntity entity, CancellationToken cancellationToken = default);
    Task<Result<IPage<TTypeEntity>>> Search(TypeSearchCriteria criteria = null, CancellationToken cancellationToken = default);
}
