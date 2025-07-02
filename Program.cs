using BanckAccount.Controllers;

namespace BanckAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            new BankAccountController().Start();
        }
    }
}