using System;

namespace YuckQi.Domain.Aspects.Abstract.Interfaces;

public interface IDeletionMoment
{
    DateTimeOffset? DeletionMoment { get; set; }
}
