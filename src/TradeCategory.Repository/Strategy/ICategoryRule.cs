namespace TradeCategory.Repository.Strategy
{
    internal interface ICategoryRule
    {
        bool Verify(Trade trade);

        string NameCategory { get; }
    }
}
