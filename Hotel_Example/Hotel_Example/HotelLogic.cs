using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel_Example
{
    public class HotelLogic
    {
        //Den här klassen representerar själva hotelet. Ett hotel har kunder. 
        //Så i den här klassen ska vi ha en lista av alla kunder.
        private List<Customer> customers;
           

        public HotelLogic()
        {
            //Här skapar vi listan
            customers = new List<Customer>();
          
        }

        //den här metoden returnerar kund-listan 
        public List<Customer> GetCustomers()
        {
            return customers;
        }

        //A private method to check if a customer is already in the list 
        //used by AddCustomer
        private bool CheckCustomerExist(Customer customer)
        {
            bool flag = false;

            foreach (Customer c in customers)
            {
                if (c.Pnr == customer.Pnr)
                {
                    flag = true;
                }
            }

            return flag;
                
            }
        

    public bool AddCustomer(Customer customer)
    {
            
        if (!CheckCustomerExist(customer))
        {
              customers.Add(customer);
              return true;
        }
        else
        {
             return false;
        }
    }

    }
}
