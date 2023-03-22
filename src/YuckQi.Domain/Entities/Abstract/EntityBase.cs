using System;

namespace YuckQi.Domain.Entities.Abstract;

public abstract class EntityBase<TIdentifier> : IEntity<TIdentifier> where TIdentifier : IEquatable<TIdentifier>
{
    public TIdentifier? Identifier { get; set; }
}
