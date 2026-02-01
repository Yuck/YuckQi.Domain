using System;
using YuckQi.Domain.Entities.Abstract.Interfaces;

namespace YuckQi.Domain.Entities.Abstract;

public abstract record DomainEntityBase<TIdentifier> : IDomainEntity<TIdentifier> where TIdentifier : IEquatable<TIdentifier>
{
    public required TIdentifier Identifier { get; set; }
}
