using TradeCategory.Repository.Interfaces;

namespace TradeCategory.Repository.Strategy
{
    internal class RuleExpired : ICategoryRule
    {
        public string NameCategory { get; }
        private DateTime _referenceDate;

        public RuleExpired(DateTime referenceDate)
        {
            _referenceDate = referenceDate;
            NameCategory = "EXPIRED";
        }

        public bool Verify(Trade trade)
        {
            var diffDate = (_referenceDate - trade.NextPaymentDate).Days;
            if (diffDate > 30)
                return true;
            else
                return false;
        }
    }
}
