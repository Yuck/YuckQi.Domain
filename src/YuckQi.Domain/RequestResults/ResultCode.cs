namespace YuckQi.Domain.RequestResults
{
    public readonly struct ResultCode
    {
        #region Private Members

        private readonly string _code;

        #endregion


        #region Implicit Operators

        public static implicit operator string(ResultCode resultCode)
        {
            return resultCode._code;
        }

        #endregion


        #region Constructors

        public ResultCode(string code)
        {
            _code = code;
        }

        #endregion


        #region Public Methods

        public override bool Equals(object obj)
        {
            return obj != null && string.Equals(this, (ResultCode) obj);
        }

        public override int GetHashCode()
        {
            return _code.GetHashCode();
        }

        public override string ToString()
        {
            return _code;
        }

        #endregion
    }
}