using System;

namespace YuckQi.Domain.Entities.Abstract;

public interface IEntity<TIdentifier> where TIdentifier : IEquatable<TIdentifier>
{
    TIdentifier? Identifier { get; set; }
}
