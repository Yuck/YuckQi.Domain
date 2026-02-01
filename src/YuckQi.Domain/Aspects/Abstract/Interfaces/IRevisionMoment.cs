using System;

namespace YuckQi.Domain.Aspects.Abstract.Interfaces;

public interface IRevisionMoment
{
    DateTimeOffset RevisionMoment { get; set; }
}
