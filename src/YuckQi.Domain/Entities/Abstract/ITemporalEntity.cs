using System;

namespace YuckQi.Domain.Entities.Abstract
{
    public interface ITemporalEntity<TKey> : IEntity<TKey> where TKey : struct
    {
        DateTime CreationMomentUtc { get; set; }
        DateTime RevisionMomentUtc { get; set; }
    }
}