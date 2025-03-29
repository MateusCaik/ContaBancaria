using System.Globalization;

namespace Exercicio1
{
    class Program
    {
        static void Main(string[] args)
        {

            ContaBancaria conta;

            Console.Write($"Entre com os dados da conta\n\nNúmero da conta: {Environment.NewLine}");
            int numero;
            while (!int.TryParse(Console.ReadLine(), out numero))
            {
                Console.Write("Número Inválido! Digite Novamente: ");
            }
            Console.Write("Nome do Titular: ");
            string nome = Console.ReadLine();
            Console.Write("Haverá depósito inicial (s/n)?");
            string resp = Console.ReadLine().ToUpper();
            if (resp == "S" || resp == "SIM")
            {
                Console.Write("Entre com o valor incial: ");
                double saldo = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                conta = new ContaBancaria(numero, nome, saldo);
            }
            else
            {
                conta = new ContaBancaria(numero, nome);
            }

            Console.WriteLine(conta);

            Console.Write("\nEntre um valor para depósito: ");
            double deposito = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            conta.Deposito(deposito);

            Console.Clear();

            Console.WriteLine("Valor Depositado: " + deposito.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine(conta);

            Console.Write("\nDeseja realizar saque (s/n)?");
            string respS = Console.ReadLine().ToUpper();

            Console.Clear();

            if (respS == "S" || respS == "SIM")
            {
                Console.Write($"Saldo Atual em conta: ${conta.Saldo.ToString("F2", CultureInfo.InvariantCulture)}");

                Console.Write("\nDigite a quantia para saque: ");
                double saque;
                while (!double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out saque) || saque <= 0)
                {
                    Console.Write("Valor Inválido! Digite um Valor para Depósito: ");
                }
                conta.Saque(saque);

                Console.Clear();

                Console.WriteLine("Valor do Saque: " + saque.ToString("F2", CultureInfo.InvariantCulture));
                Console.WriteLine(conta);
            }
            else
            {
                Console.WriteLine("Agradecemos sua Preferia com nosso Banco! \nTenha um Bom Dia.");
            }

        }
    }
}