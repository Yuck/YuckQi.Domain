using System;
using YuckQi.Domain.Entities.Abstract;

namespace YuckQi.Domain.Entities.Types.Abstract
{
    public interface ITypeEntity<TKey> : IEntity<TKey> where TKey : struct
    {
        Guid Identifier { get; set; }
        string Name { get; set; }
    }
}