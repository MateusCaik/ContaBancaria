using System.Globalization;
using BanckAccount.Models;
using BanckAccount.Utils;

namespace BanckAccount.Controllers
{
    public class BankAccountController
    {
        public void Start()
        {
            DateTime date = DateTime.Now;
            BankAccount account = AccountSetup.CreateAccount();

            Console.Clear();
            Console.WriteLine(account);

            Console.Write("\nEnter an amount to deposit: ");
            double deposit = InputValidator.GetPositiveDouble();
            account.Deposit(deposit);

            Console.Clear();
            Console.WriteLine(date.ToString("dd/MM/yyyy HH:mm") + "\n\nAmount deposited: " + deposit.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine(account);

            Console.Write("\nDo you want to make a withdrawal? (Y/N)");
            string respS = Console.ReadLine().ToUpper();
            Console.Clear();

            double sake = 0.0;

            if (respS == "Y" || respS == "YES")
            {
                Console.Write("Current account balance: $" + account.Balance.ToString("F2", CultureInfo.InvariantCulture));
                Console.Write("\nEnter the amount to withdraw: ");

                sake = InputValidator.GetValidWithdrawal(account.Balance);
                account.Sake(sake);

                Console.Clear();
                Console.WriteLine(date.ToString("dd/MM/yyyy HH:mm") + "\n\nWithdrawal amount: " + sake.ToString("F2", CultureInfo.InvariantCulture));
                Console.WriteLine(account);                               
            }
            else
            {
                Console.WriteLine("Your service has been completed. \nWe wish you a great day!");
                Console.ReadLine();
            }

            Console.Clear();
            Console.WriteLine(date.ToString("dd/MM/yyyy HH:mm") + "\n\nWithdrawal amount: " + sake.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine(account);
            Console.WriteLine("\nYour service has been completed. \nWe wish you a great day!");

            Console.ReadLine();
        }
    }
}