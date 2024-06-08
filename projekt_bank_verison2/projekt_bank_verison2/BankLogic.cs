using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace projekt_bank_verison2
{
    public class BankLogic
    {
        private readonly List<Customer> _customers;
        private readonly List<Transaction> _transactions;

        public BankLogic()
        {
            _customers = new List<Customer>();
            _transactions = new List<Transaction>();
        }

        public List<string> GetCustomers()
        {
            return _customers.Select(c => $"{c.PersonalNumber}, {c.Name}").ToList();
        }

        public bool AddCustomer(string name, long pNr)
        {
            if (_customers.Any(c => c.PersonalNumber == pNr))
                return false;

            _customers.Add(new Customer(name, pNr));
            return true;
        }

        public List<string> GetCustomer(long pNr)
        {
            var customer = _customers.FirstOrDefault(c => c.PersonalNumber == pNr);
            return customer == null ? new List<string>() : new List<string> { customer.ToString() };
        }

        public List<string> RemoveCustomer(long pNr)
        {
            var customer = _customers.FirstOrDefault(c => c.PersonalNumber == pNr);
            if (customer == null) return new List<string>();

            var result = new List<string>();
            result.AddRange(customer.SavingsAccounts.Select(account =>
            {
                var interest = account.CalculateInterest();
                return $"Kontonummer: {account.AccountNumber}, Saldo: {account.Balance}, Ränta: {interest:C}";
            }));

            result.AddRange(customer.CreditAccounts.Select(account =>
            {
                var interest = account.CalculateInterest();
                return $"Kontonummer: {account.AccountNumber}, Saldo: {account.Balance}, Ränta: {interest:C}";
            }));

            _customers.Remove(customer);
            return result;
        }

        public int AddSavingsAccount(long pNr)
        {
            var customer = _customers.FirstOrDefault(c => c.PersonalNumber == pNr);
            if (customer == null) return -1;

            var newAccount = new SavingsAccount();
            customer.AddSavingsAccount(newAccount);
            return newAccount.AccountNumber;
        }

        public int AddCreditAccount(long pNr)
        {
            var customer = _customers.FirstOrDefault(c => c.PersonalNumber == pNr);
            if (customer == null) return -1;

            var newAccount = new CreditAccount();
            customer.AddCreditAccount(newAccount);
            return newAccount.AccountNumber;
        }

        public string GetAccount(long pNr, int accountId)
        {
            var customer = _customers.FirstOrDefault(c => c.PersonalNumber == pNr);
            if (customer == null) return string.Empty;

            var account = customer.SavingsAccounts.FirstOrDefault(a => a.AccountNumber == accountId) as object ??
                          customer.CreditAccounts.FirstOrDefault(a => a.AccountNumber == accountId);
            return account?.ToString() ?? string.Empty;
        }

        public bool Deposit(long pNr, int accountId, decimal amount)
        {
            var customer = _customers.FirstOrDefault(c => c.PersonalNumber == pNr);
            if (customer == null) return false;

            var account = customer.SavingsAccounts.FirstOrDefault(a => a.AccountNumber == accountId) as dynamic ??
                          customer.CreditAccounts.FirstOrDefault(a => a.AccountNumber == accountId) as dynamic;
            if (account == null) return false;

            account.Deposit(amount);
            _transactions.Add(new Transaction(accountId, "Insättning", amount, account.Balance));
            return true;
        }

        public bool Withdraw(long pNr, int accountId, decimal amount)
        {
            var customer = _customers.FirstOrDefault(c => c.PersonalNumber == pNr);
            if (customer == null) return false;

            var account = customer.SavingsAccounts.FirstOrDefault(a => a.AccountNumber == accountId) as dynamic ??
                          customer.CreditAccounts.FirstOrDefault(a => a.AccountNumber == accountId) as dynamic;
            if (account == null || !account.Withdraw(amount)) return false;

            _transactions.Add(new Transaction(accountId, "Uttag", amount, account.Balance));
            return true;
        }

        public string CloseAccount(long pNr, int accountId)
        {
            var customer = _customers.FirstOrDefault(c => c.PersonalNumber == pNr);
            if (customer == null) return string.Empty;

            var account = customer.SavingsAccounts.FirstOrDefault(a => a.AccountNumber == accountId) as dynamic ??
                          customer.CreditAccounts.FirstOrDefault(a => a.AccountNumber == accountId) as dynamic;
            if (account == null) return string.Empty;

            Console.WriteLine("Vill du verkligen ta bort kontot? (J/N)");
            string confirmation = Console.ReadLine();
            if (confirmation.ToUpper() == "J")
            {
                decimal interest = account.CalculateInterest();
                decimal totalBalance = account.Balance + interest;

                Console.WriteLine($"Saldo: {account.Balance:C}");
                Console.WriteLine($"Ränta: {interest:C}");
                Console.WriteLine($"Totalt: {totalBalance:C}");

                if (account is SavingsAccount)
                {
                    customer.SavingsAccounts.Remove(account);
                }
                else
                {
                    customer.CreditAccounts.Remove(account);
                }

                return $"Konto stängt. Saldo: {account.Balance:C}, Ränta: {interest:C}, Totalt: {totalBalance:C}";
            }
            else
            {
                return "Borttagning avbröts av användaren.";
            }
        }


        public List<string> GetTransactions(long pNr, int accountId)
        {
            var customer = _customers.FirstOrDefault(c => c.PersonalNumber == pNr);
            if (customer == null) return new List<string>();

            var transactions = _transactions.Where(t => t.AccountId == accountId).ToList();
            return transactions.Select(t => t.ToString()).ToList();
        }
    }
}
