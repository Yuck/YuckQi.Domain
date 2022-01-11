using System;
using YuckQi.Domain.Entities.Abstract;

namespace YuckQi.Domain.Entities.MultiTenant.Abstract
{
    public abstract class MultiTenantEntityBase<TKey, TTenantKey> : EntityBase<TKey>, IMultiTenantEntity<TKey, TTenantKey> where TKey : struct where TTenantKey : struct
    {
        public TTenantKey TenantId { get; set; }

        public Boolean IsValidTenant(TTenantKey? tenantId) => TenantId.Equals(tenantId);
    }
}
