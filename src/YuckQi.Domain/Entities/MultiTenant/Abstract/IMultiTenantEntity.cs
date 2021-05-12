using System;
using YuckQi.Domain.Entities.Abstract;

namespace YuckQi.Domain.Entities.MultiTenant.Abstract
{
    public interface IMultiTenantEntity<TKey, TTenantKey> : IEntity<TKey> where TKey : struct where TTenantKey : struct
    {
        TTenantKey TenantId { get; set; }

        Boolean IsValidTenant(TTenantKey? tenantId);
    }
}