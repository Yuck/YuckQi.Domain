namespace YuckQi.Domain.Entities.Abstract
{
    public abstract class EntityBase<TKey> : IEntity<TKey> where TKey : struct
    {
        public TKey Key { get; set; }
    }
}
