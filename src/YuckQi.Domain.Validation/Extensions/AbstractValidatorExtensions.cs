using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace YuckQi.Domain.Validation.Extensions;

public static class AbstractValidatorExtensions
{
    public static Result<T> GetResult<T>(this AbstractValidator<T> validator, T item, String failedValidationMessageId)
    {
        var validationResult = validator.Validate(item);
        var result = BuildResult(validationResult, item, failedValidationMessageId);

        return result;
    }

    public static async Task<Result<T>> GetResult<T>(this AbstractValidator<T> validator, T item, String failedValidationMessageId, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(item, cancellationToken);
        var result = BuildResult(validationResult, item, failedValidationMessageId);

        return result;
    }

    private static Result<T> BuildResult<T>(ValidationResult validationResult, T item, String failedValidationMessageId)
    {
        if (validationResult == null)
            throw new ArgumentNullException(nameof(validationResult));

        if (validationResult.IsValid)
            return new Result<T>(item);

        return new Result<T>(default, GetResultDetail(validationResult, failedValidationMessageId));
    }

    private static IReadOnlyCollection<ResultDetail> GetResultDetail(ValidationResult result, String failedValidationMessageId)
    {
        return result?.Errors.Select(t => new ResultDetail(ResultCode.InvalidRequestDetail, new ResultMessage(failedValidationMessageId, t.ErrorMessage), t.PropertyName)).ToList();
    }
}
