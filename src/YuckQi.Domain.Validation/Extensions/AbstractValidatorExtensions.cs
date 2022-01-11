using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using FluentValidation.Results;

namespace YuckQi.Domain.Validation.Extensions
{
    public static class AbstractValidatorExtensions
    {
        public static Result<T> GetResult<T>(this AbstractValidator<T> validator, T item, String failedValidationMessageId)
        {
            var result = validator.Validate(item);
            if (result == null)
                throw new ArgumentNullException(nameof(result));

            if (result.IsValid)
                return new Result<T>(item);

            return new Result<T>(default, GetResultDetail(result, failedValidationMessageId));
        }

        private static IReadOnlyCollection<ResultDetail> GetResultDetail(ValidationResult result, String failedValidationMessageId)
        {
            return result?.Errors.Select(t => new ResultDetail(ResultCode.InvalidRequestDetail, new ResultMessage(failedValidationMessageId, t.ErrorMessage), t.PropertyName)).ToList();
        }
    }
}
