using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Bank
{
    public class SavingsAccount
    {
        private static int accountCounter = 1000;
        public int AccountNumber { get; private set; }
        public decimal Balance { get; private set; }
        public decimal InterestRate { get; } = 1.0m;
        public string AccountType { get; } = "Sparkonto";

        public SavingsAccount()
        {
            AccountNumber = ++accountCounter;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public bool Withdraw(decimal amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }

        public decimal CalculateInterest()
        {
            return Balance * InterestRate / 100;
        }

        public string GetAccountInfo()
        {
            return $"Kontonummer: {AccountNumber}, Saldo: {Balance:C}, Kontotyp: {AccountType}, Räntesats: {InterestRate}%";
        }
    }

}
