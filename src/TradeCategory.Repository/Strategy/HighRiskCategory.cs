using TradeCategory.Repository.Interfaces;

namespace TradeCategory.Repository.Strategy
{
    internal class HighRiskCategory : ICategoryRule
    {
        public string NameCategory { get; }

        public HighRiskCategory()
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
