using System;
using System.Collections.Generic;

namespace YuckQi.Domain.Validation.Abstract.Interfaces;

public interface IResult
{
    IReadOnlyCollection<ResultDetail> Detail { get; }
    Boolean IsValid { get; }
}

public interface IResult<T> : IResult
{
    T? Content { get; }
}
