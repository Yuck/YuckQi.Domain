namespace YuckQi.Domain.Entities.Abstract
{
    public interface IAuditedEntity<TKey, TIdentity> : ITemporalEntity<TKey> where TKey : struct
    {
        TIdentity CreatedBy { get; set; }
        TIdentity RevisedBy { get; set; }
    }
}