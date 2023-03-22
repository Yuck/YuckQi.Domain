using System;

namespace YuckQi.Domain.Validation;

public readonly struct ResultCode
{
    private readonly String _code;

    public static implicit operator String(ResultCode code) => code._code;

    public static readonly ResultCode ConstraintViolation = new(nameof(ConstraintViolation));
    public static readonly ResultCode InvalidRequestDetail = new(nameof(InvalidRequestDetail));
    public static readonly ResultCode NotFound = new(nameof(NotFound));

    public ResultCode() : this(Guid.NewGuid().ToString()) { }

    public ResultCode(String code)
    {
        _code = code;
    }

    public override Boolean Equals(Object? obj)
    {
        return obj switch
        {
            ResultCode other => String.Equals(this, other),
            String other => String.Equals(this, other),
            _ => false
        };
    }

    public override Int32 GetHashCode() => _code.GetHashCode();

    public override String ToString() => _code;
}
