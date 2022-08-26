using TradeCategory.Repository.Interfaces;

namespace TradeCategory.Repository.Strategy
{
    internal class NonIdentifiedCategory : ICategoryRule
    {
        public string NameCategory { get; }
        private DateTime _referenceDate;

        public NonIdentifiedCategory()
        {
            NameCategory = " ";
        }

        public bool Verify(Trade trade)
        {
            return true;
        }
    }
}
