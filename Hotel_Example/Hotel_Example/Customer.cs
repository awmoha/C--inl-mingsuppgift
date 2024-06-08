using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel_Example
{
    public class Customer
    {
        //Varje customer has one or more booked room
        

        //Customer has also other attributes like name, email-address and social security number
        public string Name { get; set; }
        public string Pnr { get; set; }

        

        //constructor
        public Customer(string pnr, string name)
        {
            Pnr = pnr;
            Name = name;
          
        }
    }
}
