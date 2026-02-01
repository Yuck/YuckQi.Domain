using System;

namespace YuckQi.Domain.Aspects.Abstract.Interfaces;

public interface IActivationMoment
{
    DateTimeOffset? ActivationMoment { get; set; }
}
