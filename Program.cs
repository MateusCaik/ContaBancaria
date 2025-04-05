using System.Globalization;

namespace Exercicio1
{
    class Program
    {
        static void Main(string[] args)
        {

            ContaBancaria conta;

            Console.Write($"Entre com os dados da conta\n\nNúmero da conta: ");
            int numero;
            //Teste para ver se é um INT que está sendo digitado mesmo
            while (!int.TryParse(Console.ReadLine(), out numero))
            {
                Console.Clear();
                Console.Write("Número Inválido! Digite Novamente: ");
            }

            String nome;
            Console.Write("Nome do Titular da Conta: ");
            do
            {
                nome = Console.ReadLine();
                //Verifica se tem espaço vazio e se tem numeros
                if (string.IsNullOrWhiteSpace(nome) || nome.Any(char.IsDigit))
                {
                    Console.Clear();
                    Console.Write("Nome Inválido! Digite Novamente: ");
                }
            } while (string.IsNullOrWhiteSpace(nome) || nome.Any(char.IsDigit));

            Console.Write("Haverá depósito inicial (s/n)?");
            string resp = Console.ReadLine().ToUpper();//transformar o que for digitado em CAPSLOCK
            if (resp == "S" || resp == "SIM")
            {
                Console.Write("Entre com o valor incial: ");
                double saldo;
                while (!double.TryParse(Console.ReadLine(), out saldo) || saldo <= 0)
                {
                    Console.Write("Valor Inválido para Depósito! Digite Novamente: ");
                }
                conta = new ContaBancaria(numero, nome, saldo);
            }
            else
            {
                Console.Clear();
                conta = new ContaBancaria(numero, nome);
            }

            Console.WriteLine(conta);

            Console.Write("\nEntre um valor para depósito: ");
            double deposito;
            while (!double.TryParse(Console.ReadLine(), out deposito) || deposito <= 0)
            {
                Console.Write("Valor Inválido para Depósito! Digite Novamente: ");
            }
            conta.Deposito(deposito);

            Console.Clear();

            Console.WriteLine("Valor Depositado: " + deposito.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine(conta);

            Console.Write("\nDeseja realizar saque (s/n)?");
            string respS = Console.ReadLine().ToUpper();

            Console.Clear();
            double saque = 0.0;

            if (respS == "S" || respS == "SIM")
            {
                Console.Write($"Saldo Atual em conta: ${conta.Saldo.ToString("F2", CultureInfo.InvariantCulture)}");
                Console.Write("\nDigite o Valor para Saque: ");

                do
                {

                    string sq = Console.ReadLine();

                    if (!double.TryParse(sq, NumberStyles.Float, CultureInfo.InvariantCulture, out saque) || saque <= 0)
                    {
                        Console.Clear();
                        Console.Write($"Saldo Atual em Conta: ${conta.Saldo.ToString("F2", CultureInfo.InvariantCulture)}");
                        Console.Write("\nValor Digitado: " + sq);
                        Console.Write("\nValor Inválido para Saque! Digite Novamente o Valor: ");
                    }
                    else if (saque > conta.Saldo)
                    {
                        Console.Clear();
                        Console.Write($"Saldo Atual em Conta: ${conta.Saldo.ToString("F2", CultureInfo.InvariantCulture)}");
                        Console.Write("\nValor Digitado: " + sq);
                        Console.Write("\nSaldo Insuficiente para Relização de Saque!\nDigite um Valor Menor: ");
                    }
                } while (saque <= 0 || saque > conta.Saldo);
            }
            else
            {
                Console.WriteLine("Seu Atendimento Foi Concluido. Agradecemos a confiança. \nDesejamos um ótimo dia!");
                Console.ReadLine();
            }

            conta.Saque(saque);

            Console.Clear();

            Console.WriteLine("Valor do Saque: " + saque.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine(conta);
            Console.ReadLine();

        }
    }
}