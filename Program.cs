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
                Console.Write("Número Inválido! Digite Novamente: ");
            }

            String nome;
            do
            {
                Console.Write("Nome do Titular da Conta: ");
                nome = Console.ReadLine();
                //teste para ver se são caracteres
                if (string.IsNullOrWhiteSpace(nome))
                {
                    Console.Write("Nome Inválido! Digite Novamente: ");
                }
            } while (string.IsNullOrWhiteSpace(nome));

            Console.Write("Haverá depósito inicial (s/n)?");
            string resp = Console.ReadLine().ToUpper();//transformar o que for digitado em CAPSLOCK
            if (resp == "S" || resp == "SIM")
            {
                Console.Write("Entre com o valor incial: ");
                double saldo;
                while (!double.TryParse(Console.ReadLine(), out saldo) || saldo <= 0)
                {
                    Console.Write("Valor Inválido para Depósito! Digite Novamente: ")
                }
                conta = new ContaBancaria(numero, nome, saldo);
            }
            else
            {
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

            if (respS == "S" || respS == "SIM")
            {
                Console.Write($"Saldo Atual em conta: ${conta.Saldo.ToString("F2", CultureInfo.InvariantCulture)}");
                double saque;
                do
                {
                    Console.Write("\nDigite o Valor para Saque: ");

                    if (!double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.InvariantCulture, out saque) || saque <= 0)
                    {
                        Console.Write("Valor Inválido para Saque! Digite Novamente o Valor: ");
                    }
                    else if (conta.Saldo < saque)
                    {
                        Console.Write("Saldo Insuficiente para Relização de Saque!\nDigite um Valor Menor: ");
                    }
                } while (saque <= 0 || conta.Saldo < saque);

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