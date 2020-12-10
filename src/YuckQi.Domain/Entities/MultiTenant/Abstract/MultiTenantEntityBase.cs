using YuckQi.Domain.Entities.Abstract;

namespace YuckQi.Domain.Entities.MultiTenant.Abstract
{
    public abstract class MultiTenantEntityBase<TKey, TTenantKey> : EntityBase<TKey>, IMultiTenantEntity<TKey, TTenantKey> where TKey : struct where TTenantKey : struct
    {
        public TTenantKey TenantId { get; set; }

        public bool IsValidTenant(TTenantKey? tenantId)
        {
            return TenantId.Equals(tenantId);
        }
    }
}