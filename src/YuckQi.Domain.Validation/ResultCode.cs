using System;

namespace YuckQi.Domain.Validation;

public readonly struct ResultCode
{
    #region Private Members

    private readonly String _code;

    #endregion


    #region Implicit Operators

    public static implicit operator String(ResultCode resultCode) => resultCode._code;

    #endregion


    #region Constants

    public static readonly ResultCode ConstraintViolation = new(nameof(ConstraintViolation));
    public static readonly ResultCode InvalidRequestDetail = new(nameof(InvalidRequestDetail));
    public static readonly ResultCode NotFound = new(nameof(NotFound));

    #endregion


    #region Constructors

    public ResultCode(String code)
    {
        _code = code;
    }

    #endregion


    #region Public Methods

    public override Boolean Equals(Object obj) => obj != null && String.Equals(this, (ResultCode) obj);

    public override Int32 GetHashCode() => _code.GetHashCode();

    public override String ToString() => _code;

    #endregion
}
