namespace TradeCategory.Repository.Strategy
{
    internal class RuleNone : ICategoryRule
    {
        public string NameCategory { get; }
        private DateTime _referenceDate;

        public RuleNone()
        {
            NameCategory = " ";
        }

        public bool Verify(Trade trade)
        {
            return true;
        }
    }
}
