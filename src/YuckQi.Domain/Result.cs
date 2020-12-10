using System.Collections.Generic;
using System.Linq;

namespace YuckQi.Domain
{
    public class Result
    {
        #region Properties

        public IEnumerable<ResultDetail> Detail { get; }

        public bool IsValid => Detail.All(t => t.Type != ResultType.Error);

        #endregion
    }

    public class Result<T> : Result
    {
        #region Properties

        public T Payload { get; }

        #endregion


        #region Constructors

        public Result(T payload)
        {
            Payload = payload;
        }

        #endregion
    }
}