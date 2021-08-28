using System;
using System.Collections.Generic;
using System.Globalization;
using DioBank.Entities;
using DioBank.Entities.Enums;

namespace DioBank
{
    class Program
    {
        private static List<Account> _list = new List<Account>();

        static void Main(string[] args)
        {
            string option = GetUserOption();

            while (option.ToUpper() != "X")
            {
                switch (option)
                {
                    case "1":
                        ListAccounts();
                        break;
                    case "2":
                        AddNewAccount();
                        break;
                    case "3":
                        // Transfer();
                        break;
                    case "4":
                        // Withdraw();
                        break;
                    case "5":
                        // Deposit();
                        break;
                    case "C":
                        Console.Clear();                        
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }

                option = GetUserOption();
            }

            Console.WriteLine("Encerrando o sistema...");
            Console.WriteLine("Obrigado por utilizar nossos serviços");
            Console.WriteLine("Até logo!");
        }

        static string GetUserOption()
        {
            Console.WriteLine("Bem vindo ao DIO Bank");
            Console.WriteLine("Informe a opção desejada");
            Console.WriteLine();
            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferência entre contas");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();
            Console.Write("Opção: ");

            string chosenOption = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return chosenOption;
        }

        static void ListAccounts()
        {
            if (_list.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("[Lista de contas]");
                Console.WriteLine();

                foreach (Account account in _list)
                {
                    Console.WriteLine(account);
                    Console.WriteLine();
                }
            }            
        }

        static void AddNewAccount()
        {
            Console.WriteLine("[Inserir nova conta]");
            Console.WriteLine();

            Console.Write("Informe o nome do titular: ");
            string holder = Console.ReadLine();
            Console.Write("Informe o saldo inicial: ");
            double balance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Informe o limite de crédito: ");
            double limit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Digite 1 para conta física ou 2 para conta jurídica: ");
            int typeAccount = int.Parse(Console.ReadLine());
            _list.Add(new Account(holder, balance, limit, (AccountType)typeAccount));

            Console.WriteLine();
            Console.WriteLine("Conta cadastrada com sucesso");
            Console.WriteLine();
        }
    }
}
