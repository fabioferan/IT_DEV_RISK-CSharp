namespace TradeCategory.Repository
{
    internal class Trade: ITrade
    {
        public double Value { get; set; }
        public string? ClientSector { get; set; }
        public DateTime NextPaymentDate { get; set; }
    }
}
