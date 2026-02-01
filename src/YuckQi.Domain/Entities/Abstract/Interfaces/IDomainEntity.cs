using System;

namespace YuckQi.Domain.Entities.Abstract.Interfaces;

public interface IDomainEntity<TIdentifier> where TIdentifier : IEquatable<TIdentifier>
{
    TIdentifier Identifier { get; set; }
}
