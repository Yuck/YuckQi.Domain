using System;
using System.Collections.Generic;
using System.Linq;

namespace YuckQi.Domain.Validation;

public class Result
{
    #region Properties

    public IReadOnlyCollection<ResultDetail> Detail { get; }

    public Boolean IsValid => Detail.All(t => t.Type != ResultType.Error);

    #endregion


    #region Constructors

    public Result(IReadOnlyCollection<ResultDetail> detail)
    {
        Detail = detail ?? Array.Empty<ResultDetail>();
    }

    #endregion
}

public class Result<T> : Result
{
    #region Properties

    public T Payload { get; }

    #endregion


    #region Constructors

    public Result(ResultDetail detail) : this(new List<ResultDetail> { detail }) { }

    public Result(IReadOnlyCollection<ResultDetail> detail) : base(detail) { }

    public Result(T payload, IReadOnlyCollection<ResultDetail> detail = null) : base(detail)
    {
        Payload = payload;
    }

    #endregion


    #region Public Methods

    public static Result<T> ConstraintViolation<TKey>(TKey key, String message = null) where TKey : struct => new(ResultDetail.ConstraintViolation<T, TKey>(key, message));

    public Boolean HasResultCode(ResultCode resultCode) => Detail.Any(t => t.Code == resultCode);

    public static Result<T> NotFound<TKey>(TKey key, String message = null) where TKey : struct => new(ResultDetail.NotFound<T, TKey>(key, message));

    #endregion
}
