using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt_bank_verison2
{
    public class Transaction
    {
        public int AccountId { get; }
        public DateTime Date { get; }
        public string Type { get; }
        public decimal Amount { get; }
        public decimal Balance { get; }

        public Transaction(int accountId, string type, decimal amount, decimal balance)
        {
            AccountId = accountId;
            Date = DateTime.Now;
            Type = type;
            Amount = amount;
            Balance = balance;
        }

        public override string ToString()
        {
            return $"[{Date}] {Type}: {Amount:C}, Saldo efter transaktion: {Balance:C}";
        }
    }


}
