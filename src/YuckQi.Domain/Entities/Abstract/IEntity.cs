namespace YuckQi.Domain.Entities.Abstract
{
    public interface IEntity<TKey> where TKey : struct
    {
        TKey Key { get; set; }
    }
}