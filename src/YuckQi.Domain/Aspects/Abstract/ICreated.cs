using System;

namespace YuckQi.Domain.Aspects.Abstract
{
    public interface ICreated
    {
        DateTime CreationMomentUtc { get; set; }
    }
}