using System;

namespace YuckQi.Domain.Validation;

public record ResultCode
{
    private readonly String _code;

    public static implicit operator ResultCode(String code) => new (code);
    public static implicit operator String(ResultCode code) => code._code;

    public static readonly ResultCode InvalidRequestDetail = new (nameof(InvalidRequestDetail));
    public static readonly ResultCode NotFound = new (nameof(NotFound));

    public ResultCode() : this(Guid.NewGuid().ToString()) { }

    public ResultCode(String code)
    {
        _code = code;
    }

    public override Int32 GetHashCode() => _code.GetHashCode();

    public override String ToString() => this;
}
