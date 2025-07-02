using System.Globalization;

namespace BanckAccount.Utils
{
    public static class InputValidator
    {
        public static double GetPositiveDouble()
        {
            double value;
            while (!double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.InvariantCulture, out value) || value <= 0)
            {
                Console.Write("Invalid amount! Please enter a positive number: ");
            }
            return value;
        }

        public static double GetValidWithdrawal(double currentBalance)
        {
            double amount;
            while (true)
            {
                string input = Console.ReadLine();
                if (!double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out amount) || amount <= 0)
                {
                    Console.WriteLine("Invalid amount! Please enter a positive number: ");
                }
                else if (amount > currentBalance)
                {
                    Console.WriteLine("Insufficient balance. Enter a smaller amount: ");
                }
                else
                {
                    return amount;
                }
            }
        }
    }
}