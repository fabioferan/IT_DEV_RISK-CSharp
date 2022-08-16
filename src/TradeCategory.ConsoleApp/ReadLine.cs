using TradeCategory.Repository;

namespace TradeCategory.ConsoleApp
{
    internal class ReadLine
    {
        private DateTime _referenceDate;

        internal void Read()
        {
            Category category = new();

            try
            {
                SetRefenceDate();

                int numTrades;
                if (int.TryParse(Console.ReadLine(), out numTrades))
                {
                    for (int i = 1; i <= numTrades; i++)
                    {
                        SetTrade(category);
                    }

                    Console.WriteLine();

                    category.GetCategory().ForEach(delegate (string s) {
                        Console.WriteLine(s);
                    });
                }
                else
                {
                    throw new ArgumentException("Number of lines is not valid.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void SetRefenceDate()
        {
            var referenceDate = Console.ReadLine();

            if (string.IsNullOrEmpty(referenceDate))
                throw new ArgumentException("Date is null or empty.", referenceDate);

            if (!DateTime.TryParse(referenceDate, new System.Globalization.CultureInfo("en-US"),
                                       System.Globalization.DateTimeStyles.None, out _referenceDate))
                throw new ArgumentException("Unable to convert to a date and time.",
                                  referenceDate);
        }

        private void SetTrade(Category category)
        {
            var errorMessage = string.Empty;
            string _clientSector = string.Empty;
            double _value;
            DateTime _nextPaymentDate;

            var lineElements = Console.ReadLine();

            if (string.IsNullOrEmpty(lineElements))
                throw new ArgumentException("Line elements is null or empty.");
            
            var elements = lineElements.Split(" ");

            if (elements.Length == 3)
            {
                if(!double.TryParse(elements[0], out _value))
                    errorMessage += $"{Environment.NewLine} Value is not valid: {elements[0]}";

                if(elements[1] == "Private" || elements[1] == "Public")
                    _clientSector = elements[1];
                else
                    errorMessage += $"{Environment.NewLine} Client sector is not valid: {elements[1]}";

                if (!DateTime.TryParse(elements[2], new System.Globalization.CultureInfo("en-US"),
                                       System.Globalization.DateTimeStyles.None, out _nextPaymentDate))
                    errorMessage += $"{Environment.NewLine} Next payment date is not valid: {elements[0]}";

                if(string.IsNullOrEmpty(errorMessage))
                    category.SetTrade(_value, _clientSector, _nextPaymentDate, _referenceDate);
                else
                    throw new ArgumentException(errorMessage);
            }
            else
                throw new ArgumentException($"Number of elements is not valid: {elements.Length}");
        }
    }
}
