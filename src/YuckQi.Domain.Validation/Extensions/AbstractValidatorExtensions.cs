using System;
using System.Linq;
using FluentValidation;

namespace YuckQi.Domain.Validation.Extensions
{
    public static class AbstractValidatorExtensions
    {
        private const string AbstractValidatorFailedMessageId = "YQDV.01";

        public static Result<T> GetResult<T>(this AbstractValidator<T> validator, T item)
        {
            var result = validator.Validate(item);
            if (result == null)
                throw new ArgumentNullException(nameof(result));

            if (result.IsValid)
                return new Result<T>(item);

            return new Result<T>(default, result.Errors.Select(t => new ResultDetail(ResultCode.InvalidRequestDetail, new ResultMessage(AbstractValidatorFailedMessageId, t.ErrorMessage), t.PropertyName)).ToList());
        }
    }
}