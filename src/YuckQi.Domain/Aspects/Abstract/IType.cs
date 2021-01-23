using System;

namespace YuckQi.Domain.Aspects.Abstract
{
    public interface IType
    {
        Guid Identifier { get; set; }
        string Name { get; set; }
        string ShortName { get; set; }
    }
}