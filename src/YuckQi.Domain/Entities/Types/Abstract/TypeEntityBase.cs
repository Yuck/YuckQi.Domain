using System;
using YuckQi.Domain.Entities.Abstract;

namespace YuckQi.Domain.Entities.Types.Abstract
{
    public abstract class TypeEntityBase<TKey> : EntityBase<TKey>, ITypeEntity<TKey> where TKey : struct
    {
        public Guid Identifier { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}