using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt_bank_verison2
{
    public class Customer
    {
        public string Name { get; set; }
        public long PersonalNumber { get; }
        public List<SavingsAccount> SavingsAccounts { get; }
        public List<CreditAccount> CreditAccounts { get; }

        public Customer(string name, long personalNumber)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            PersonalNumber = personalNumber;
            SavingsAccounts = new List<SavingsAccount>();
            CreditAccounts = new List<CreditAccount>();
        }

        public void AddSavingsAccount(SavingsAccount account)
        {
            SavingsAccounts.Add(account);
        }

        public void AddCreditAccount(CreditAccount account)
        {
            CreditAccounts.Add(account);
        }

        public override string ToString()
        {
            var accountsInfo = SavingsAccounts.Select(a => a.ToString()).Concat(CreditAccounts.Select(c => c.ToString()));
            return $"Kund: {Name}, Personnummer: {PersonalNumber}\nKonton:\n{string.Join("\n", accountsInfo)}";
        }
    }
}
