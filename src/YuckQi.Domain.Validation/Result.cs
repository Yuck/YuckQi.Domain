using System.Collections.Generic;
using System.Linq;

namespace YuckQi.Domain.Validation
{
    public class Result
    {
        #region Properties

        public IReadOnlyCollection<ResultDetail> Detail { get; }

        public bool IsValid => Detail.All(t => t.Type != ResultType.Error);

        #endregion


        #region Constructors

        public Result(IReadOnlyCollection<ResultDetail> detail)
        {
            Detail = detail;
        }

        #endregion
    }

    public class Result<T> : Result
    {
        #region Properties

        public T Payload { get; }

        #endregion


        #region Constructors

        public Result(ResultDetail detail) : base(new List<ResultDetail> { detail })
        {
        }

        public Result(T payload, IReadOnlyCollection<ResultDetail> detail = null) : base(detail)
        {
            Payload = payload;
        }

        #endregion
    }
}