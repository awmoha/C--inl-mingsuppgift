using System.Collections.Generic;
using System.Linq;


namespace Bank_Applikation.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public long PersonalNumber { get; private set; }
        public List<SavingsAccount> Accounts { get; private set; }

        public Customer(string name, long personalNumber)
        {
            Name = name;
            PersonalNumber = personalNumber;
            Accounts = new List<SavingsAccount>();
        }

        public List<string> GetCustomerAccounts()
        {
            return Accounts.Select(account => account.GetAccountInfo()).ToList();
        }
    }

}