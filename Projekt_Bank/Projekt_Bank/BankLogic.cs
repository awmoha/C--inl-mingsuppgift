using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Bank
{
    public class BankLogic
    {
        private List<Customer> customers = new List<Customer>();

        public List<string> GetCustomers()
        {
            return customers.Select(c => $"{c.PersonalNumber} - {c.Name}").ToList();
        }

        public bool AddCustomer(string name, long pNr)
        {
            if (customers.Any(c => c.PersonalNumber == pNr))
            {
                return false;
            }

            customers.Add(new Customer(name, pNr));
            return true;
        }

        public List<string> GetCustomer(long pNr)
        {
            var customer = customers.FirstOrDefault(c => c.PersonalNumber == pNr);
            if (customer == null)
            {
                return null;
            }

            var customerInfo = new List<string> { customer.GetCustomerInfo() };
            customerInfo.AddRange(customer.Accounts.Select(a => a.GetAccountInfo()));
            return customerInfo;
        }

        public List<string> RemoveCustomer(long pNr)
        {
            var customer = customers.FirstOrDefault(c => c.PersonalNumber == pNr);
            if (customer == null)
            {
                return null;
            }

            var accountInfo = customer.Accounts.Select(a => {
                decimal interest = a.CalculateInterest();
                return $"Kontonummer: {a.AccountNumber}, Saldo: {a.Balance:C}, Ränta: {interest:C}";
            }).ToList();

            customers.Remove(customer);
            return accountInfo;
        }

        public int AddSavingsAccount(long pNr)
        {
            var customer = customers.FirstOrDefault(c => c.PersonalNumber == pNr);
            if (customer == null)
            {
                return -1;
            }

            var account = new SavingsAccount();
            customer.Accounts.Add(account);
            return account.AccountNumber;
        }

        public string GetAccount(long pNr, int accountId)
        {
            var customer = customers.FirstOrDefault(c => c.PersonalNumber == pNr);
            if (customer == null)
            {
                return null;
            }

            var account = customer.Accounts.FirstOrDefault(a => a.AccountNumber == accountId);
            return account?.GetAccountInfo();
        }

        public bool Deposit(long pNr, int accountId, decimal amount)
        {
            var customer = customers.FirstOrDefault(c => c.PersonalNumber == pNr);
            if (customer == null)
            {
                return false;
            }

            var account = customer.Accounts.FirstOrDefault(a => a.AccountNumber == accountId);
            if (account == null)
            {
                return false;
            }

            account.Deposit(amount);
            return true;
        }

        public bool Withdraw(long pNr, int accountId, decimal amount)
        {
            var customer = customers.FirstOrDefault(c => c.PersonalNumber == pNr);
            if (customer == null)
            {
                return false;
            }

            var account = customer.Accounts.FirstOrDefault(a => a.AccountNumber == accountId);
            if (account == null || !account.Withdraw(amount))
            {
                return false;
            }

            return true;
        }

        public string CloseAccount(long pNr, int accountId)
        {
            var customer = customers.FirstOrDefault(c => c.PersonalNumber == pNr);
            if (customer == null)
            {
                return null;
            }

            var account = customer.Accounts.FirstOrDefault(a => a.AccountNumber == accountId);
            if (account == null)
            {
                return null;
            }

            Console.Write("Vill du verkligen ta bort kontot (J/N)? ");
            string confirmation = Console.ReadLine().ToUpper();
            if (confirmation != "J")
            {
                return "Kontot har inte tagits bort.";
            }

            decimal interest = account.CalculateInterest();
            string accountInfo = $"Kontonummer: {account.AccountNumber}, Saldo: {account.Balance:C}, Ränta: {interest:C}";
            customer.Accounts.Remove(account);
            return accountInfo;
        }

    }
}
