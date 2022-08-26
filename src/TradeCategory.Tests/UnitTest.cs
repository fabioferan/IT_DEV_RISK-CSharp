using TradeCategory.Repository;

namespace TradeCategory.Tests
{
    public class UnitTest
    {
        [Fact]
        public void Test_Expired()
        {
            string _clientSector = "Public";
            double _value = 400000;
            DateTime _nextPaymentDate = new DateTime(2020,07, 01);
            DateTime _referenceDate = new DateTime(2020, 12, 11);

            CategoryReport category = new();
            category.SetTrade(_value, _clientSector, _nextPaymentDate, _referenceDate);
            var result = category.GetCategory().ToArray();

            Assert.Equal("EXPIRED", result[0]);
        }

        [Fact]
        public void Test_HighRisk()
        {
            string _clientSector = "Private";
            double _value = 2000000;
            DateTime _nextPaymentDate = new DateTime(2025, 12, 29);
            DateTime _referenceDate = new DateTime(2020, 12, 11);

            CategoryReport category = new();
            category.SetTrade(_value, _clientSector, _nextPaymentDate, _referenceDate);
            var result = category.GetCategory().ToArray();

            Assert.Equal("HIGHRISK", result[0]);
        }

        [Fact]
        public void Test_MediumMRisk()
        {
            string _clientSector = "Public";
            double _value = 5000000;
            DateTime _nextPaymentDate = new DateTime(2024, 01, 02);
            DateTime _referenceDate = new DateTime(2020, 12, 11);

            CategoryReport category = new();
            category.SetTrade(_value, _clientSector, _nextPaymentDate, _referenceDate);
            var result = category.GetCategory().ToArray();

            Assert.Equal("MEDIUMRISK", result[0]);
        }
    }
}