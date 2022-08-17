using TradeCategory.Repository.Interfaces;

namespace TradeCategory.Repository.Strategy
{
    internal class RuleMediumRisk : ICategoryRule
    {
        public string NameCategory { get; }

        public RuleMediumRisk()
        {
            NameCategory = "MEDIUMRISK";
        }

        public bool Verify(Trade trade)
        {
            if (trade.Value > 1000000 && trade.ClientSector == "Public")
                return true;
            else
                return false;
        }
    }
}
