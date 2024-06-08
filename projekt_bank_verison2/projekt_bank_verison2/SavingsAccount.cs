using System;
using System.Collections.Generic;

namespace projekt_bank_verison2
{

    public class SavingsAccount
    {
        private static int _accountNumberSeed = 1001;
        public int AccountNumber { get; }
        public decimal Balance { get; private set; }
        public const decimal InterestRate = 1.0m;
        public string AccountType => "Sparkonto";

        public SavingsAccount()
        {
            AccountNumber = _accountNumberSeed++;
            Balance = 0;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            Balance += amount;
        }

        public bool Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance < amount)
            {
                return false;
            }
            Balance -= amount;
            return true;
        }

        public decimal CalculateInterest()
        {
            return Balance * InterestRate / 100;
        }

        public override string ToString()
        {
            return $"Kontonummer: {AccountNumber}, Saldo: {Balance:C}, Kontotyp: {AccountType}, Räntesats: {InterestRate}%";
        }
    }
}
