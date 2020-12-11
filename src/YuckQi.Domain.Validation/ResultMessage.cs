namespace YuckQi.Domain.Validation
{
    public readonly struct ResultMessage
    {
        #region Properties

        public string Id { get; }
        public string Text { get; }

        #endregion


        #region Constructors

        public ResultMessage(string id, string text = null)
        {
            Id = id;
            Text = text;
        }

        #endregion
    }
}