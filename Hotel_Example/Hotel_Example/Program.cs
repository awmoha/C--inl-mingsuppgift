using System;
using System.Collections.Generic;

namespace Hotel_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            //Vi skapar bara ett objekt av HotelLogic i och med att den här appen ska 
            //representera ett hotel.
            HotelLogic myHotel = new HotelLogic();                    

            int option;            

            bool run = true;

            while (run)
            {
                Console.WriteLine("Welcome, please choose from the following menu:" +
                              "\n" + "1. Show list of all customer" +
                              "\n" + "2. Add a new customer " +
                              "\n" + "3. Exit");

                bool success = Int32.TryParse(Console.ReadLine(), out option);

                switch (option)
                {
                    case 1:
                        {
                            //Anropar GetCustomer på objektet av HotelLogic 
                            List<Customer> customers = myHotel.GetCustomers();
                            
                            //Vi går igenom listan och skriver ut alla kunder
                            foreach (Customer c in customers)
                            { Console.WriteLine("Name: " + c.Name + "Personnummer: " + c.Pnr); }
                            break;
                        }

                    case 2:
                        {
                            Console.WriteLine("Input the personnumber: ");
                            string pnr = Console.ReadLine();

                            Console.WriteLine("Input the name: ");
                            string name = Console.ReadLine();

                            //Här skapar vi ett objekt av Customer med info som vi har fått från användaren
                            Customer newCustomer = new Customer(pnr, name);

                            //Vi lägger till objektet i kund-listan i HotelLogic
                            //genom att anropa metoden AddCustomer
                            bool result=myHotel.AddCustomer(newCustomer);

                            if (result)
                               Console.WriteLine("Customer added!"); 
                            else
                                Console.WriteLine("Customer is already exist");

                            break;

                        }

                    case 3:
                        {
                            run = false;
                            break;
                        }
                }
            }
        }
    }
}
