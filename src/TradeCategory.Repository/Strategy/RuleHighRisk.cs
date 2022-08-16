namespace TradeCategory.Repository.Strategy
{
    internal class RuleHighRisk : ICategoryRule
    {
        public string NameCategory { get; }

        public RuleHighRisk()
        {
            NameCategory = "HIGHRISK";
        }

        public bool Verify(Trade trade)
        {
            if (trade.Value > 1000000 && trade.ClientSector == "Private")
                return true;
            else
                return false;
        }
    }
}
