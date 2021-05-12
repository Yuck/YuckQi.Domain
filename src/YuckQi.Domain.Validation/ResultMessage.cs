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
    }
}