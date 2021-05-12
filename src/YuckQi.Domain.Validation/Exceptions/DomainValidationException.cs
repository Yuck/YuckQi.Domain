using System;
using System.Linq;

namespace YuckQi.Domain.Validation.Exceptions
{
    public class DomainValidationException : ApplicationException
    {
        #region Constants

        private const String DefaultErrorMessage = "Something went wrong.";

        #endregion


        #region Properties

        public Result Result { get; }

        #endregion


        #region Constructors

        public DomainValidationException(Result result) : base(GetErrorMessage(result))
        {
            Result = result;
        }

        #endregion


        #region Supporting Methods

        private static String GetErrorMessage(Result result)
        {
            if (result == null)
                return DefaultErrorMessage;

            var count = result.Detail.Count(t => t.Type == ResultType.Error);
            var noun = count == 1 ? "error" : "errors";
            var message = $"Domain model has {count} {noun} after validation.";

            return message;
        }

        #endregion
    }
}