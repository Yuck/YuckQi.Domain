using System;
using YuckQi.Domain.Entities.Abstract;

namespace YuckQi.Domain.Entities.MultiTenant.Abstract;

public interface IMultiTenantEntity<TIdentifier, TTenantIdentifier> : IEntity<TIdentifier> where TIdentifier : IEquatable<TIdentifier> where TTenantIdentifier : IEquatable<TTenantIdentifier>
{
    TTenantIdentifier? TenantIdentifier { get; set; }

    Boolean IsValidTenant(TTenantIdentifier? tenantIdentifier);
}
