using System;

namespace YuckQi.Domain.Aspects.Abstract
{
    public interface IRevised
    {
        DateTime RevisionMomentUtc { get; set; }
    }
}