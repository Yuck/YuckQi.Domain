using System;

namespace YuckQi.Domain.Validation;

public class ResultDetail
{
    #region Private Members

    private readonly ResultCode _code;

    #endregion


    #region Constants

    public static ResultDetail ConstraintViolation<T, TIdentifier>(TIdentifier identifier, String message = null) where TIdentifier : struct => new(ResultCode.ConstraintViolation, ResultMessage.ConstraintConflict<T, TIdentifier>(identifier, message));
    public static ResultDetail NotFound<T, TIdentifier>(TIdentifier identifier, String message = null) where TIdentifier : struct => new(ResultCode.NotFound, ResultMessage.NotFound<T, TIdentifier>(identifier, message));

    #endregion


    #region Properties

    public ResultMessage Message { get; }
    public String Property { get; }
    public ResultType Type { get; }

    public String Code => _code;

    #endregion


    #region Constructors

    public ResultDetail(ResultCode code, ResultMessage message, String property = null, ResultType type = ResultType.Error)
    {
        _code = code;

        Message = message;
        Property = property;
        Type = type;
    }

    #endregion
}
