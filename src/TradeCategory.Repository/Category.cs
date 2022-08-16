using System.Diagnostics;

namespace TradeCategory.Repository
{
    public class Category
    {
        private DateTime referenceDate { get; set; }

        List<Trade> trades;

        public Category()
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
            RuleExpired ruleExpired = new RuleExpired(referenceDate);
            RuleHighRisk ruleHighRisk = new RuleHighRisk();
            RuleMediumRisk ruleMediumRisk = new RuleMediumRisk();
            
            List<ICategoryRule> categoryRules = new();
            categoryRules.Add(ruleExpired);
            categoryRules.Add(ruleHighRisk);
            categoryRules.Add(ruleMediumRisk);
            
            List<string> categories = new();

            try
            {
                foreach (var trade in trades)
                {
                    foreach(var categoryRule in categoryRules)
                    {
                        if (categoryRule.Verify(trade))
                        {
                            categories.Add(categoryRule.NameCategory);
                            break;
                        }
                        else
                            categories.Add(" ");
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

    interface ICategoryRule
    {
        bool Verify(Trade trade);

        string NameCategory { get; }
    }

    internal class RuleExpired : ICategoryRule
    {
        public string NameCategory { get; }    
        private DateTime _referenceDate;

        public RuleExpired(DateTime referenceDate)
        {
            _referenceDate = referenceDate;
            NameCategory = "Expired";
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

    internal class RuleHighRisk : ICategoryRule
    {
        public string NameCategory { get; }

        public RuleHighRisk()
        {
            NameCategory = "HIGHRISK";
        }

        public bool Verify(Trade trade)
        {
            if (trade.Value == 10000000 && trade.ClientSector == "Public")
                return true;
            else
                return false;
        }
    }

    internal class RuleMediumRisk : ICategoryRule
    {
        public string NameCategory { get; }

        public RuleMediumRisk()
        {
            NameCategory = "MEDIUMRISK";
        }

        public bool Verify(Trade trade)
        {
            if (trade.Value == 10000000 && trade.ClientSector == "Private")
                return true;
            else
                return false;
        }
    }
}
