namespace YuckQi.Domain.Validation
{
    public class ResultDetail
    {
        #region Properties

        public ResultCode Code { get; }
        public ResultMessage Message { get; }
        public string Property { get; }
        public ResultType Type { get; }

        #endregion


        #region Constructors

        public ResultDetail(ResultCode code, ResultMessage message, string property = null, ResultType type = ResultType.Error)
        {
            Code = code;
            Message = message;
            Property = property;
            Type = type;
        }

        #endregion
    }
}