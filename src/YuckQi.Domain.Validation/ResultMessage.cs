using System;

namespace YuckQi.Domain.Validation;

public record ResultMessage
{
    public static ResultMessage NotFound<T, TIdentifier>(TIdentifier identifier, String? message = null) where TIdentifier : IEquatable<TIdentifier> => new (message ?? $"'{typeof(T).Name}' '{identifier}' could not be found.");

    private readonly String _message;

    public static implicit operator ResultMessage(String message) => new (message);
    public static implicit operator String(ResultMessage message) => message._message;

    public ResultMessage() : this(String.Empty) { }

    public ResultMessage(String message)
    {
        _message = message;
    }

    public override String ToString() => this;
}
