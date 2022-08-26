using TradeCategory.Repository.Interfaces;

namespace TradeCategory.Repository.Strategy
{
    internal class ExpiredCategory : ICategoryRule
    {
        public string NameCategory { get; }
        private DateTime _referenceDate;

        public ExpiredCategory(DateTime referenceDate)
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
