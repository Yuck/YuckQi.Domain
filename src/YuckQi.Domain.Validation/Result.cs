using System;
using System.Collections.Generic;
using System.Linq;

namespace YuckQi.Domain.Validation
{
    public class Result
    {
        #region Properties

        public IReadOnlyCollection<ResultDetail> Detail { get; }

        public Boolean IsValid => Detail != null && Detail.Any(t => t.Type == ResultType.Error);

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

        public Result(ResultDetail detail) : base(new List<ResultDetail> { detail }) { }

        public Result(T payload, IReadOnlyCollection<ResultDetail> detail = null) : base(detail)
        {
            Payload = payload;
        }

        #endregion


        #region Public Methods

        public static Result<T> ConstraintViolation<TKey>(TKey key, String message = null) where TKey : struct => new Result<T>(ResultDetail.ConstraintViolation<T, TKey>(key, message));

        public Boolean IsConstraintConflict => Detail.Any(t => String.Equals(t.Code, ResultCode.ConstraintViolation));

        public Boolean IsNotFound => Detail.Any(t => String.Equals(t.Code, ResultCode.NotFound));

        public static Result<T> NotFound<TKey>(TKey key, String message = null) where TKey : struct => new Result<T>(ResultDetail.NotFound<T, TKey>(key, message));

        #endregion
    }
}
