using System;
using YuckQi.Domain.Entities.Abstract;

namespace YuckQi.Domain.Entities.MultiTenant.Abstract;

public abstract class MultiTenantEntityBase<TIdentifier, TTenantIdentifier> : EntityBase<TIdentifier>, IMultiTenantEntity<TIdentifier, TTenantIdentifier> where TIdentifier : IEquatable<TIdentifier> where TTenantIdentifier : IEquatable<TTenantIdentifier>
{
    public TTenantIdentifier? TenantIdentifier { get; set; }

    public Boolean IsValidTenant(TTenantIdentifier? tenantIdentifier) => Equals(TenantIdentifier, tenantIdentifier);
}
