using System;
using System.Collections.Generic;
using System.Linq;

namespace YuckQi.Domain.Validation;

public class Result
{
    public IReadOnlyCollection<ResultDetail> Detail { get; }

    public Boolean IsValid => Detail.All(t => t.Type != ResultType.Error);

    public Result(IReadOnlyCollection<ResultDetail>? detail)
    {
        Detail = detail ?? Array.Empty<ResultDetail>();
    }
}

public class Result<T> : Result
{
    public T? Content { get; }

    public Result(ResultDetail detail) : this(new List<ResultDetail> { detail }) { }

    public Result(IReadOnlyCollection<ResultDetail> detail) : base(detail) { }

    public Result(T? content, IReadOnlyCollection<ResultDetail>? detail = null) : base(detail)
    {
        Content = content;
    }

    public Boolean HasResultCode(ResultCode resultCode) => Detail.Any(t => t.Code == resultCode);

    public static Result<T> NotFound<TIdentifier>(TIdentifier identifier, String? message = null) where TIdentifier : IEquatable<TIdentifier> => new (ResultDetail.NotFound<T, TIdentifier>(identifier, message));
}
