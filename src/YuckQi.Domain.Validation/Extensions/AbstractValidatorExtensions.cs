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
    public static Result<T> GetResult<T>(this IValidator<T> validator, T item)
    {
        ArgumentNullException.ThrowIfNull(validator);

        var validationResult = validator.Validate(item);
        var result = BuildResult(validationResult, item);

        return result;
    }

    public static Result<T> GetResult<T>(this AbstractValidator<T> validator, T item) => GetResult(validator as IValidator<T>, item);

    public static async Task<Result<T>> GetResult<T>(this IValidator<T> validator, T item, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(validator);

        var validationResult = await validator.ValidateAsync(item, cancellationToken);
        var result = BuildResult(validationResult, item);

        return result;
    }

    public static Task<Result<T>> GetResult<T>(this AbstractValidator<T> validator, T item, CancellationToken cancellationToken) => GetResult(validator as IValidator<T>, item, cancellationToken);

    private static Result<T> BuildResult<T>(ValidationResult validationResult, T item)
    {
        ArgumentNullException.ThrowIfNull(validationResult);

        if (validationResult.IsValid)
            return new Result<T>(item);

        return new Result<T>(default, GetResultDetail(validationResult));
    }
    
    private static IReadOnlyCollection<ResultDetail> GetResultDetail(ValidationResult result)
    {
        return [..result.Errors.Select(t => new ResultDetail(new ResultMessage(t.ErrorMessage), ResultCode.InvalidRequestDetail, t.PropertyName))];
    }
}
