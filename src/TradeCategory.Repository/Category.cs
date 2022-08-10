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

            Trade trade = new Trade();
            trade.Value = value;
            trade.ClientSector = clientSector;
            trade.NextPaymentDate = nextPaymentDate;

            trades.Add(trade);
        }

        public List<string> GetCategory()
        {
            List<string> categories = new List<string>();

            try
            {
                foreach (var trade in trades)
                {
                    int diffDate = (referenceDate - trade.NextPaymentDate).Days;

                    if (diffDate > 30)
                        categories.Add("EXPIRED");
                    else if (trade.Value > 1000000)
                    {
                        if (trade.ClientSector == "Private")
                            categories.Add("HIGHRISK");
                        if (trade.ClientSector == "Public")
                            categories.Add("MEDIUMRISK");
                    }
                    else
                        categories.Add(" ");
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
