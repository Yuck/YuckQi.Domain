using System;

namespace YuckQi.Domain.Aspects.Abstract;

public interface IDeleted
{
    DateTime? DeletionMomentUtc { get; set; }
}
