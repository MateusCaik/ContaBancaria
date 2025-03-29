using System.Globalization;

namespace Exercicio1
{
    class ContaBancaria
    {

        public int Numero { get; private set; }
        public string Titular { get; private set; }
        public double Saldo { get; private set; }

        //construtor sem depósito inicial
        public ContaBancaria(int numero, string titular)
        {
            Numero = numero;
            Titular = titular;
        }

        //construtor com depósito inicial
        public ContaBancaria(int numero, string titular, double depositoInicial) : this(numero, titular)
        {
            Deposito(depositoInicial);
        }

        public void Deposito(double quantia)
        {
            Saldo += quantia;
        }

        public void Saque(double quantia)
        {
            if (quantia >= 1000.00)
            {
                Saldo -= quantia + 50.0;//Descontar 50 reais, caso seja de 1k||>>
            }
            else
            {
                Saldo -= quantia + 5.0;//Descontar 5 reais de saque
            }

        }

        public override string ToString()
        {
            return "\nNúmero da Conta: " + Numero
                + "\nTitular: " + Titular
                + "\nSaldo em conta: $ " + Saldo.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
