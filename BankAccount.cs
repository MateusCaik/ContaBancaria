using System.Globalization;

namespace Exercicio1
{
    public class BankAccount
    {

        public int Number { get; private set; }
        public string Holder { get; private set; }
        public double Balance { get; private set; }

        //construtor sem depósito inicial
        public BankAccount(int number, string holder)
        {
            Number = number;
            Holder = holder;
        }

        //construtor com depósito inicial
        public BankAccount(int number, string holder, double initialDeposit) : this(number, holder)
        {
            Deposit(initialDeposit);
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public void Sake(double amount)
        {
            if (amount>= 1000.00)
            {
                Balance -= amount + 50.0;//Descontar 50 reais, caso seja de 1k||>>
            }
            else
            {
                Balance -= amount + 5.0;//Descontar 5 reais de saque
            }

        }

        public override string ToString()
        {
            return "\nAccount number: " + Number
                + "\nAccounter holder: " + Holder
                + "\nAccount balance: $ " + Balance.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
