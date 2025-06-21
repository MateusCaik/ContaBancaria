using System;
using System.Globalization;

namespace Exercicio1
{
    class Program
    {
        static void Main(string[] args)
        {

            ContaBancaria account;

            Console.Write($"Enter account details\n\nAccount number: ");
            int number;
            //Teste para ver se é um INT que está sendo digitado mesmo
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.Clear();
                Console.Write("Invalid Number! Type it again: ");
            }

            String name;
            Console.Write("Account holder name: ");
            do
            {
                name = Console.ReadLine();
                //Verifica se tem espaço vazio e se tem numeros
                if (string.IsNullOrWhiteSpace(name) || name.Any(char.IsDigit))
                {
                    Console.Clear();
                    Console.Write("Invalid name! Type it again: ");
                }
            } while (string.IsNullOrWhiteSpace(name) || name.Any(char.IsDigit));

            Console.Write("Will there be an initial deposit? (Y/N)");
            string resp = Console.ReadLine().ToUpper();//transformar o que for digitado em CAPSLOCK
            if (resp == "Y" || resp == "YES")
            {
                Console.Write("Enter the initial value: ");
                double balance;
                while (!double.TryParse(Console.ReadLine(), out balance) || balance <= 0)
                {
                    Console.Write("Invalid amount for deposit! Type it again: ");
                }
                account = new ContaBancaria(number, name, balance);
            }
            else
            {
                Console.Clear();
                account = new ContaBancaria(number, name);
            }

            Console.WriteLine(account);

            Console.Write("\nEnter an amount to deposit: ");
            double deposit;
            while (!double.TryParse(Console.ReadLine(), out deposit) || deposit <= 0)
            {
                Console.Write("Invalid amount for deposit! Type it again: ");
            }
            account.Deposit(deposit);

            Console.Clear();

            Console.WriteLine("Amount deposited: " + deposit.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine(account);

                Console.Write("\nDo you want to make a withdrawal? (Y/N)");
            string respS = Console.ReadLine().ToUpper();

            Console.Clear();
            double sake = 0.0;

            if (respS == "Y" || respS == "YES")
            {
                Console.Write($"Current account balance: ${account.Balance.ToString("F2", CultureInfo.InvariantCulture)}");
                Console.Write("\nEnter the amount to withdraw: ");

                do
                {

                    string sq = Console.ReadLine();

                    if (!double.TryParse(sq, NumberStyles.Float, CultureInfo.InvariantCulture, out sake) || sake <= 0)
                    {
                        Console.Clear();
                        Console.Write($"Current account balance: ${account.Balance.ToString("F2", CultureInfo.InvariantCulture)}");
                        Console.Write("\nRequested amount: " + sq);
                        Console.Write("\nInvalid amount for withdrawal! Enter the value again: ");
                    }
                    else if (sake > account.Balance)
                    {
                        Console.Clear();
                        Console.Write($"Current account balance: ${account.Balance.ToString("F2", CultureInfo.InvariantCulture)}");
                        Console.Write("\nRequested amount: " + sq);
                        Console.Write("\nInsufficient balance to make withdrawal!\nEnter a lower value: ");
                    }
                } while (sake <= 0 || sake > account.Balance);
            }
            else
            {
                Console.WriteLine("Your service has been completed. \nWe wish you a great day!");
                Console.ReadLine();
            }

            account.Sake(sake);

            Console.Clear();

            Console.WriteLine("Withdrawal amount: " + sake.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine(account);
            Console.ReadLine();

        }
    }
}