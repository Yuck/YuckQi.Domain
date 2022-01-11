using System;

namespace YuckQi.Domain.Aspects.Abstract
{
    public interface IActivated
    {
        DateTime? ActivationMomentUtc { get; set; }
    }
}
