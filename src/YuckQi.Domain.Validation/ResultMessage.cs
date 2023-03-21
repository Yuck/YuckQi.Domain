using System;

namespace YuckQi.Domain.Validation;

public readonly struct ResultMessage
{
    private readonly String _message;

    public static implicit operator String(ResultMessage message) => message._message;

    public ResultMessage() : this(String.Empty) { }

    public ResultMessage(String message)
    {
        _message = message;
    }

    public static ResultMessage ConstraintConflict<T, TIdentifier>(TIdentifier identifier, String? message = null) where TIdentifier : IEquatable<TIdentifier> => new(message ?? $"'{typeof(T).Name}' '{identifier}' already exists.");

    public static ResultMessage NotFound<T, TIdentifier>(TIdentifier identifier, String? message = null) where TIdentifier : IEquatable<TIdentifier> => new(message ?? $"'{typeof(T).Name}' '{identifier}' could not be found.");

    public override String ToString() => _message;
}
