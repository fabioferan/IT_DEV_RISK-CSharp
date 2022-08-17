namespace TradeCategory.Repository.Interfaces
{
    internal interface ICategoryRule
    {
        bool Verify(Trade trade);

        string NameCategory { get; }
    }
}
