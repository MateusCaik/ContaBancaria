using System;
using System.Globalization;

namespace Exercicio1
{
    class Program
    {
        static void Main(string[] args)
        {

            ContaBancaria conta;

            Console.Write("Entre com os dados da conta\n\nNúmero da conta: ");
            int numero = int.Parse(Console.ReadLine());
            Console.Write("Nome do Titular: ");
            string nome = Console.ReadLine();
            Console.Write("Haverá depósito inicial (s/n)?");
            string resp = Console.ReadLine();
            if (resp == "s" ||  resp == "S" ||  resp == "sim" ||  resp == "Sim")
            {
                Console.Write("Entre com o valor incial: ");
                double saldo = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                conta = new ContaBancaria(numero, nome, saldo);           
            }
            else
            {
                conta = new ContaBancaria(numero, nome);
            }
            
            Console.Clear();

            Console.WriteLine("Dados da conta\n" + conta);

            Console.Write("\nEntre um valor para depósito: ");
            double deposito = double.Parse(Console.ReadLine() , CultureInfo.InvariantCulture);
            conta.Deposito(deposito);

            Console.Clear();

            Console.WriteLine("Valor do depósito: " + deposito.ToString("F2", CultureInfo.InvariantCulture));
            Console.Write("\nDados da conta atualizados\n" + conta);

            Console.Write("\nDeseja realizar saque (s/n)?");
            string respS = Console.ReadLine();
            Console.Clear();

            Console.Write($"Saldo Atual em conta: ${conta.Saldo.ToString("F2", CultureInfo.InvariantCulture)}");
            if (respS == "S" || respS == "s" || respS == "Sim" || respS == "sim")
            {
                Console.Write("\nDigite a quantia para saque: ");
                double saque = double.Parse(Console.ReadLine() , CultureInfo.InvariantCulture);
                conta.Saque(saque);

                Console.WriteLine("Valor do Saque: " + saque.ToString("F2", CultureInfo.InvariantCulture));
                Console.Write("\nDados da conta atualizados\n" + conta);
            }
            else
            {

            }

        }
    }
}