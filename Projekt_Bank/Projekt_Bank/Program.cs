using Projekt_Bank;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        BankLogic bankLogic = new BankLogic();

        while (true)
        {
            Console.WriteLine("1. Lägg till kund");
            Console.WriteLine("2. Ta bort kund");
            Console.WriteLine("3. Lägg till sparkonto");
            Console.WriteLine("4. Stäng konto");
            Console.WriteLine("5. Visa kundinformation");
            Console.WriteLine("6. Sätt in pengar");
            Console.WriteLine("7. Ta ut pengar");
            Console.WriteLine("8. Avsluta");
            Console.Write("Välj ett alternativ: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Ange namn: ");
                    string name = Console.ReadLine();
                    Console.Write("Ange personnummer: ");
                    long pNr = long.Parse(Console.ReadLine());
                    if (bankLogic.AddCustomer(name, pNr))
                    {
                        Console.WriteLine("Kund tillagd.");
                    }
                    else
                    {
                        Console.WriteLine("Kund med detta personnummer finns redan.");
                    }
                    break;

                case 2:
                    Console.Write("Ange personnummer: ");
                    pNr = long.Parse(Console.ReadLine());
                    List<string> removedAccounts = bankLogic.RemoveCustomer(pNr);
                    if (removedAccounts != null)
                    {
                        Console.WriteLine("Kund borttagen. Följande konton stängdes:");
                        removedAccounts.ForEach(Console.WriteLine);
                    }
                    else
                    {
                        Console.WriteLine("Kund ej hittad.");
                    }
                    break;

                case 3:
                    Console.Write("Ange personnummer: ");
                    pNr = long.Parse(Console.ReadLine());
                    int accountId = bankLogic.AddSavingsAccount(pNr);
                    if (accountId != -1)
                    {
                        Console.WriteLine($"Sparkonto skapat med kontonummer: {accountId}");
                    }
                    else
                    {
                        Console.WriteLine("Kund ej hittad.");
                    }
                    break;

                case 4:
                    Console.Write("Ange personnummer: ");
                    pNr = long.Parse(Console.ReadLine());
                    Console.Write("Ange kontonummer: ");
                    accountId = int.Parse(Console.ReadLine());
                    string closedAccountInfo = bankLogic.CloseAccount(pNr, accountId);
                    if (closedAccountInfo != null)
                    {
                        Console.WriteLine("Konto stängt. Information:");
                        Console.WriteLine(closedAccountInfo);
                    }
                    else
                    {
                        Console.WriteLine("Kund eller konto ej hittat.");
                    }
                    break;

                case 5:
                    Console.Write("Ange personnummer: ");
                    pNr = long.Parse(Console.ReadLine());
                    List<string> customerInfo = bankLogic.GetCustomer(pNr);
                    if (customerInfo != null)
                    {
                        customerInfo.ForEach(Console.WriteLine);
                    }
                    else
                    {
                        Console.WriteLine("Kund ej hittad.");
                    }
                    break;

                case 6:
                    Console.Write("Ange personnummer: ");
                    pNr = long.Parse(Console.ReadLine());
                    Console.Write("Ange kontonummer: ");
                    accountId = int.Parse(Console.ReadLine());
                    Console.Write("Ange belopp: ");
                    decimal amount = decimal.Parse(Console.ReadLine());
                    if (bankLogic.Deposit(pNr, accountId, amount))
                    {
                        Console.WriteLine("Insättning lyckades.");
                    }
                    else
                    {
                        Console.WriteLine("Kund eller konto ej hittat.");
                    }
                    break;

                case 7:
                    Console.Write("Ange personnummer: ");
                    pNr = long.Parse(Console.ReadLine());
                    Console.Write("Ange kontonummer: ");
                    accountId = int.Parse(Console.ReadLine());
                    Console.Write("Ange belopp: ");
                    amount = decimal.Parse(Console.ReadLine());
                    if (bankLogic.Withdraw(pNr, accountId, amount))
                    {
                        Console.WriteLine("Uttag lyckades.");
                    }
                    else
                    {
                        Console.WriteLine("Kund, konto ej hittat eller otillräckligt saldo.");
                    }
                    break;

                case 8:
                    return;

                default:
                    Console.WriteLine("Ogiltigt val.");
                    break;
            }

            Console.WriteLine();
        }
    }
}
