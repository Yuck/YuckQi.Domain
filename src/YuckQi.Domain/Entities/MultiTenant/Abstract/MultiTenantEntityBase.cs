using System;
using YuckQi.Domain.Entities.Abstract;

namespace YuckQi.Domain.Entities.MultiTenant.Abstract;

public abstract class MultiTenantEntityBase<TIdentifier, TTenantIdentifier> : EntityBase<TIdentifier>, IMultiTenantEntity<TIdentifier, TTenantIdentifier> where TIdentifier : struct where TTenantIdentifier : struct
{
    public TTenantIdentifier TenantIdentifier { get; set; }

    public Boolean IsValidTenant(TTenantIdentifier? tenantIdentifier) => TenantIdentifier.Equals(tenantIdentifier);
}
