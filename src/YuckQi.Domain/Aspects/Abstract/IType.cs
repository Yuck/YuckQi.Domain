using System;

namespace YuckQi.Domain.Aspects.Abstract
{
    public interface IType
    {
        Guid Identifier { get; set; }
        String Name { get; set; }
        String ShortName { get; set; }
    }
}
