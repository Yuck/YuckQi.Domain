using System;

namespace YuckQi.Domain.Validation
{
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

        public static ResultMessage ConstraintConflict<T, TKey>(TKey key, String message = null) where TKey : struct => new ResultMessage($"{ResultCode.ConstraintViolation.GetHashCode()}", message ?? $"'{typeof(T).Name}' '{key}' already exists.");
        public static ResultMessage NotFound<T, TKey>(TKey key, String message = null) where TKey : struct => new ResultMessage($"{ResultCode.NotFound.GetHashCode()}", message ?? $"'{typeof(T).Name}' '{key}' could not be found.");

        #endregion
    }
}
