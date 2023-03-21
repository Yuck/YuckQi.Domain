using System;

namespace YuckQi.Domain.Validation;

public class ResultDetail
{
    public static ResultDetail ConstraintViolation<T, TIdentifier>(TIdentifier identifier, String? message = null) where TIdentifier : IEquatable<TIdentifier> => new(ResultMessage.ConstraintConflict<T, TIdentifier>(identifier, message), ResultCode.ConstraintViolation);
    public static ResultDetail NotFound<T, TIdentifier>(TIdentifier identifier, String? message = null) where TIdentifier : IEquatable<TIdentifier> => new(ResultMessage.NotFound<T, TIdentifier>(identifier, message), ResultCode.NotFound);

    public ResultCode? Code { get; }
    public ResultMessage Message { get; }
    public String? Property { get; }
    public ResultType Type { get; }

    public ResultDetail(ResultMessage message, ResultCode? code = null, String? property = null, ResultType type = ResultType.Error)
    {
        Code = code;
        Message = message;
        Property = property;
        Type = type;
    }

    public ResultDetail(String message, ResultCode? code = null, String? property = null, ResultType type = ResultType.Error) : this(new ResultMessage(message), code, property, type) { }
}
