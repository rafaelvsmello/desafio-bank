using System;
using System.Globalization;
using DioBank.Entities.Enums;

namespace DioBank.Entities
{
    public class Account
    {
        public string Holder { get; set; }
        public double Balance { get; private set; }
        public double Limit { get; private set; }
        public AccountType AccountType { get; private set; }

        public Account(string holder, double balance, double limit, AccountType accountType)
        {
            Holder = holder;
            Balance = balance;
            Limit = limit;
            AccountType = accountType;
        }

        public bool Withdraw(double amount)
        {
            if (Balance - amount < (Limit * -1))
            {
                Console.WriteLine("Saldo insuficiente");
                Console.WriteLine();
                return false;
            }

            Balance -= amount;
            Console.WriteLine("Saque realizado");
            Console.WriteLine("Saldo atualizado: {0}", Balance.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine();

            return true;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
            Console.WriteLine("Depósito realizado");
            Console.WriteLine("Saldo atualizado: {0}", Balance.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine();
        }

        public void Transfer(double amount, Account account)
        {
            if (Withdraw(amount))
            {
                account.Deposit(amount);
            }

            Console.WriteLine("Saldo atualizado: {0}", account.Balance.ToString("F2", CultureInfo.InvariantCulture));
        }

        public override string ToString()
        {
            return "Tipo de Conta: " + AccountType +
                "\nNome do Titular: " + Holder +
                "\nSaldo: " + Balance.ToString("F2", CultureInfo.InvariantCulture) +
                "\nLimite de Crédito: " + Limit.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
