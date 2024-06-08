using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Bank
{
    public class Customer
    {
        public string Name { get; set; }
        public long PersonalNumber { get; }
        public List<SavingsAccount> Accounts { get; }

        public Customer(string name, long personalNumber)
        {
            Name = name;
            PersonalNumber = personalNumber;
            Accounts = new List<SavingsAccount>();
        }

        public string GetCustomerInfo()
        {
            return $"Namn: {Name}, Personnummer: {PersonalNumber}";
        }
    }
}
