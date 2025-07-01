namespace Exercicio1
{
    public class AccountSetup
    {
        public static BankAccount CreateAccount()
        {
            Console.Write($"Enter account details\n\nAccount number: ");
            int number;
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.Clear();
                Console.Write("Invalid Number! Type it again: ");
            }

            string name;
            Console.Write("Account holder name: ");
            do
            {
                name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name) || name.Any(char.IsDigit))
                {
                    Console.Clear();
                    Console.Write("Invalid name! Type it again: ");
                }
            } while (string.IsNullOrWhiteSpace(name) || name.Any(char.IsDigit));

            Console.Write("Will there be an initial deposit? (Y/N): ");
            string resp = Console.ReadLine().ToUpper();

            if (resp == "Y" || resp == "YES")
            {
                Console.Write("Enter the initial value: ");
                double balance;
                while (!double.TryParse(Console.ReadLine(), out balance) || balance <= 0)
                {
                    Console.Write("Invalid amount for deposit! Type it again: ");
                }
                return new BankAccount(number, name, balance);
            }
            else
            {
                Console.Clear();
                return new BankAccount(number, name);
            }
        }
    }
}