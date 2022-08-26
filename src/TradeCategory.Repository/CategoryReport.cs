using System.Diagnostics;
using TradeCategory.Repository.Strategy;
using System.Linq;
using TradeCategory.Repository.Interfaces;

namespace TradeCategory.Repository
{
    public class CategoryReport
    {
        private DateTime referenceDate { get; set; }

        List<Trade> trades;

        public CategoryReport()
        {
            trades = new List<Trade>();
        }

        public void SetTrade(double value, string clientSector, DateTime nextPaymentDate, DateTime referenceDate)
        {
            this.referenceDate = referenceDate;

            Trade trade = new();
            trade.Value = value;
            trade.ClientSector = clientSector;
            trade.NextPaymentDate = nextPaymentDate;
            trades.Add(trade);
        }

        public List<string> GetCategory()
        {
            var expiredCategory = new ExpiredCategory(referenceDate);
            var highRiskCategory = new HighRiskCategory();
            var mediumRiskCategory = new MediumRiskCategory();
            var nonIdentifiedCategory = new NonIdentifiedCategory();

            List<ICategoryRule> categoryRules = new()
            {
                expiredCategory,
                highRiskCategory,
                mediumRiskCategory,
                nonIdentifiedCategory
            };

            List<string> categories = new();

            try
            {
                foreach (var trade in trades)
                {
                    foreach (var categoryRule in categoryRules)
                    {
                        if (categoryRule.Verify(trade))
                        {
                            categories.Add(categoryRule.NameCategory);
                            break;
                        }
                    }
                }

                return categories;
            }
            catch
            {
                throw;
            }
        }
    }
}
