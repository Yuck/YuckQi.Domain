using System;

namespace YuckQi.Domain.Validation;

public readonly struct ResultMessage
{
    #region Properties

    public String Id { get; }
    public String Text { get; }

    #endregion


    #region Constructors

    public ResultMessage(String id, String text = null)
    {
        Id = id;
        Text = text;
    }

    #endregion


    #region Public Methods

    public static ResultMessage ConstraintConflict<T, TIdentifier>(TIdentifier identifier, String message = null) where TIdentifier : struct => new($"{ResultCode.ConstraintViolation.GetHashCode()}", message ?? $"'{typeof(T).Name}' '{identifier}' already exists.");
    public static ResultMessage NotFound<T, TIdentifier>(TIdentifier identifier, String message = null) where TIdentifier : struct => new($"{ResultCode.NotFound.GetHashCode()}", message ?? $"'{typeof(T).Name}' '{identifier}' could not be found.");

    #endregion
}
