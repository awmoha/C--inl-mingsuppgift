using System.Collections.Generic;
using System.Linq;

namespace Bank_Applikation.Models
{
    public class BankLogic
    {
        private List<Customer> customers;
        private int nextAccountNumber = 1001;

        public BankLogic()
        {
            customers = new List<Customer>();
        }

        public List<string> GetCustomers()
        {
            return customers.Select(c => $"{c.PersonalNumber} {c.Name}").ToList();
        }

        public bool AddCustomer(string name, long pNr)
        {
            if (!customers.Any(c => c.PersonalNumber == pNr))
            {
                customers.Add(new Customer(name, pNr));
                return true;
            }
            return false;
        }

        public List<string> GetCustomer(long pNr)
        {
            var customer = customers.FirstOrDefault(c => c.PersonalNumber == pNr);
            if (customer != null)
            {
                var result = new List<string> { $"{customer.PersonalNumber} {customer.Name}" };
                result.AddRange(customer.GetCustomerAccounts());
                return result;
            }
            return new List<string> { "Customer not found." };
        }

        public List<string> RemoveCustomer(long pNr)
        {
            var customer = customers.FirstOrDefault(c => c.PersonalNumber == pNr);
            if (customer != null)
            {
                var result = new List<string>();
                foreach (var account in customer.Accounts)
                {
                    decimal interest = account.CalculateInterest();
                    result.Add($"Account {account.AccountNumber} closed. Returned Balance: {account.Balance}, Interest: {interest}");
                }
                customers.Remove(customer);
                return result;
            }
            return new List<string> { "Customer not found." };
        }

        public int AddSavingsAccount(long pNr)
        {
            var customer = customers.FirstOrDefault(c => c.PersonalNumber == pNr);
            if (customer != null)
            {
                var account = new SavingsAccount(nextAccountNumber++);
                customer.Accounts.Add(account);
                return account.AccountNumber;
            }
            return -1;
        }

        public string GetAccount(long pNr, int accountId)
        {
            var customer = customers.FirstOrDefault(c => c.PersonalNumber == pNr);
            if (customer != null)
            {
                var account = customer.Accounts.FirstOrDefault(a => a.AccountNumber == accountId);
                if (account != null)
                {
                    return account.GetAccountInfo();
                }
            }
            return "Account not found.";
        }

        public bool Deposit(long pNr, int accountId, decimal amount)
        {
            var account = GetCustomerAccount(pNr, accountId);
            if (account != null)
            {
                account.Deposit(amount);
                return true;
            }
            return false;
        }

        public bool Withdraw(long pNr, int accountId, decimal amount)
        {
            var account = GetCustomerAccount(pNr, accountId);
            if (account != null)
            {
                return account.Withdraw(amount);
            }
            return false;
        }

        public string CloseAccount(long pNr, int accountId)
        {
            var customer = customers.FirstOrDefault(c => c.PersonalNumber == pNr);
            if (customer != null)
            {
                var account = customer.Accounts.FirstOrDefault(a => a.AccountNumber == accountId);
                if (account != null)
                {
                    customer.Accounts.Remove(account);
                    decimal interest = account.CalculateInterest();
                    return $"Account {accountId} closed. Returned Balance: {account.Balance + interest}, Interest: {interest}";
                }
            }
            return "Account not found.";
        }

        private SavingsAccount GetCustomerAccount(long pNr, int accountId)
        {
            var customer = customers.FirstOrDefault(c => c.PersonalNumber == pNr);
            return customer?.Accounts.FirstOrDefault(a => a.AccountNumber == accountId);
        }
    }

}