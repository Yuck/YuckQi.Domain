using YuckQi.Domain.Entities.Abstract;

namespace YuckQi.Domain.Entities.Types
{
    public abstract class TypeEntityBase<TKey> : EntityBase<TKey> where TKey : struct
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}