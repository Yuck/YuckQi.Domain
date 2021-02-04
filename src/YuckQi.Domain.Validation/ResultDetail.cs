namespace YuckQi.Domain.Validation
{
    public class ResultDetail
    {
        #region Private Members

        private readonly ResultCode _code;

        #endregion


        #region Properties

        public ResultMessage Message { get; }
        public string Property { get; }
        public ResultType Type { get; }

        public string Code => _code;

        #endregion


        #region Constructors

        public ResultDetail(ResultCode code, ResultMessage message, string property = null, ResultType type = ResultType.Error)
        {
            _code = code;

            Message = message;
            Property = property;
            Type = type;
        }

        #endregion
    }
}