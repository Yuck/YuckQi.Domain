using System;

namespace YuckQi.Domain.Entities.Abstract
{
    public abstract record TypeEntityBase<TIdentifier> : DomainEntityBase<TIdentifier> where TIdentifier : IEquatable<TIdentifier>
    {
        public required String Name { get; set; }
        public String? ShortName { get; set; }
    }
}
