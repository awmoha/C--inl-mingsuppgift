using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt_bank_verison2
{
    public class CreditAccount
    {
        private static int _accountNumberSeed = 2001;
        public int AccountNumber { get; }
        public decimal Balance { get; private set; }
        public const decimal CreditLimit = -5000.0m;
        public const decimal PositiveInterestRate = 0.5m;
        public const decimal NegativeInterestRate = 7.0m;
        public string AccountType => "Kreditkonto";

        public CreditAccount()
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
            if (Balance - amount < CreditLimit)
            {
                return false;
            }
            Balance -= amount;
            return true;
        }

        public decimal CalculateInterest()
        {
            if (Balance >= 0)
            {
                return Balance * PositiveInterestRate / 100;
            }
            else
            {
                return Balance * NegativeInterestRate / 100;
            }
        }

        public override string ToString()
        {
            return $"Kontonummer: {AccountNumber}, Saldo: {Balance:C}, Kontotyp: {AccountType}, Räntesats: {(Balance >= 0 ? PositiveInterestRate : NegativeInterestRate)}%";
        }
    }
}
