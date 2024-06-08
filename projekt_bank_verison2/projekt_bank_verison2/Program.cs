using System;
using System.Collections.Generic;

namespace projekt_bank_verison2
{
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
                Console.WriteLine("4. Lägg till kreditkonto");
                Console.WriteLine("5. Stäng konto");
                Console.WriteLine("6. Visa kundinformation");
                Console.WriteLine("7. Sätt in pengar");
                Console.WriteLine("8. Ta ut pengar");
                Console.WriteLine("9. Visa transaktioner");
                Console.WriteLine("10. Avsluta");
                Console.Write("Välj ett alternativ: ");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Ange namn: ");
                        string name = Console.ReadLine();
                        Console.Write("Ange personnummer: ");
                        if (long.TryParse(Console.ReadLine(), out long pNr))
                        {
                            if (bankLogic.AddCustomer(name, pNr))
                            {
                                Console.WriteLine("Kund tillagd.");
                            }
                            else
                            {
                                Console.WriteLine("Kund med detta personnummer finns redan.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ogiltigt personnummer.");
                        }
                        break;

                    case 2:
                        Console.Write("Ange personnummer: ");
                        if (long.TryParse(Console.ReadLine(), out pNr))
                        {
                            List<string> removedAccounts = bankLogic.RemoveCustomer(pNr);
                            if (removedAccounts != null && removedAccounts.Count > 0)
                            {
                                Console.WriteLine("Kund borttagen. Följande konton stängdes:");
                                removedAccounts.ForEach(Console.WriteLine);
                            }
                            else
                            {
                                Console.WriteLine("Kund ej hittad.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ogiltigt personnummer.");
                        }
                        break;

                    case 3:
                        Console.Write("Ange personnummer: ");
                        if (long.TryParse(Console.ReadLine(), out pNr))
                        {
                            int accountId = bankLogic.AddSavingsAccount(pNr);
                            if (accountId != -1)
                            {
                                Console.WriteLine($"Sparkonto skapat med kontonummer: {accountId}");
                            }
                            else
                            {
                                Console.WriteLine("Kund ej hittad.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ogiltigt personnummer.");
                        }
                        break;

                    case 4:
                        Console.Write("Ange personnummer: ");
                        if (long.TryParse(Console.ReadLine(), out pNr))
                        {
                            int accountId = bankLogic.AddCreditAccount(pNr);
                            if (accountId != -1)
                            {
                                Console.WriteLine($"Kreditkonto skapat med kontonummer: {accountId}");
                            }
                            else
                            {
                                Console.WriteLine("Kund ej hittad.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ogiltigt personnummer.");
                        }
                        break;

                    case 5:
                        Console.Write("Ange personnummer: ");
                        if (long.TryParse(Console.ReadLine(), out pNr))
                        {
                            Console.Write("Ange kontonummer: ");
                            if (int.TryParse(Console.ReadLine(), out int accountId))
                            {
                                string closedAccountInfo = bankLogic.CloseAccount(pNr, accountId);
                                if (!string.IsNullOrEmpty(closedAccountInfo))
                                {
                                    Console.WriteLine("Konto stängt. Information:");
                                    Console.WriteLine(closedAccountInfo);
                                }
                                else
                                {
                                    Console.WriteLine("Kund eller konto ej hittat.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ogiltigt kontonummer.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ogiltigt personnummer.");
                        }
                        break;

                    case 6:
                        Console.Write("Ange personnummer: ");
                        if (long.TryParse(Console.ReadLine(), out pNr))
                        {
                            List<string> customerInfo = bankLogic.GetCustomer(pNr);
                            if (customerInfo != null && customerInfo.Count > 0)
                            {
                                customerInfo.ForEach(Console.WriteLine);
                            }
                            else
                            {
                                Console.WriteLine("Kund ej hittad.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ogiltigt personnummer.");
                        }
                        break;

                    case 7:
                        Console.Write("Ange personnummer: ");
                        if (long.TryParse(Console.ReadLine(), out pNr))
                        {
                            Console.Write("Ange kontonummer: ");
                            if (int.TryParse(Console.ReadLine(), out int accountId))
                            {
                                Console.Write("Ange belopp: ");
                                if (decimal.TryParse(Console.ReadLine(), out decimal amount))
                                {
                                    if (bankLogic.Deposit(pNr, accountId, amount))
                                    {
                                        Console.WriteLine("Insättning lyckades.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Kund eller konto ej hittat.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Ogiltigt belopp.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ogiltigt kontonummer.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ogiltigt personnummer.");
                        }
                        break;

                    case 8:
                        Console.Write("Ange personnummer: ");
                        if (long.TryParse(Console.ReadLine(), out pNr))
                        {
                            Console.Write("Ange kontonummer: ");
                            if (int.TryParse(Console.ReadLine(), out int accountId))
                            {
                                Console.Write("Ange belopp: ");
                                if (decimal.TryParse(Console.ReadLine(), out decimal amount))
                                {
                                    if (bankLogic.Withdraw(pNr, accountId, amount))
                                    {
                                        Console.WriteLine("Uttag lyckades.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Kund, konto ej hittat eller otillräckligt saldo.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Ogiltigt belopp.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ogiltigt kontonummer.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ogiltigt personnummer.");
                        }
                        break;

                    case 9:
                        Console.Write("Ange personnummer: ");
                        if (long.TryParse(Console.ReadLine(), out pNr))
                        {
                            Console.Write("Ange kontonummer: ");
                            if (int.TryParse(Console.ReadLine(), out int accountId))
                            {
                                List<string> transactions = bankLogic.GetTransactions(pNr, accountId);
                                if (transactions != null && transactions.Count > 0)
                                {
                                    transactions.ForEach(Console.WriteLine);
                                }
                                else
                                {
                                    Console.WriteLine("Inga transaktioner hittades för detta konto.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ogiltigt kontonummer.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ogiltigt personnummer.");
                        }
                        break;

                    case 10:
                        return;

                    default:
                        Console.WriteLine("Ogiltigt val.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
