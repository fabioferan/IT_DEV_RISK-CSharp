namespace TradeCategory.Repository
{
    internal static class CategoryHelpers
    {
        public static List<string> GetCategories(List<Trade> trades)
        {
            List<string> categories = new List<string>();

            try
            {
                foreach (var trade in trades)
                {
                    if (trade.Value > 1000000)
                    {
                        if (trade.ClientSector == "Private")
                            categories.Add("HIGHRISK");
                        if (trade.ClientSector == "Public")
                            categories.Add("MEDIUMRISK");
                    }
                    if (trade.Value < 1000000 && trade.ClientSector == "Public")
                        categories.Add("LOWRISK");
                }
                return categories;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}