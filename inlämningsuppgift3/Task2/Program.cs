using System;

class BankApplication
{
    private static double balance = 0;

    static void Main()
    {
        Console.WriteLine("Welcome to the Simplistic Bank Application!");

        // Get user's name
        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine();

        // Display welcome message with user's name and current date/time
        DisplayWelcomeMessage(userName);

        bool isRunning = true;

        while (isRunning)
        {
            ShowMenu();

            // Get user input
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DepositMoney();
                    break;

                case "2":
                    WithdrawMoney();
                    break;

                case "3":
                    isRunning = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void DisplayWelcomeMessage(string userName)
    {
        Console.WriteLine($"Hello, {userName}!");
        Console.WriteLine($"Current date and time: {DateTime.Now}");
        Console.WriteLine("Let's manage your account.\n");
    }

    static void ShowMenu()
    {
        Console.WriteLine("Menu:");
        Console.WriteLine("1. Deposit money");
        Console.WriteLine("2. Withdraw money");
        Console.WriteLine("3. Leave");
        Console.Write("Enter your choice: ");
    }

    static void DepositMoney()
    {
        Console.Write("Enter the amount to deposit: ");
        if (double.TryParse(Console.ReadLine(), out double amount) && amount > 0)
        {
            balance += amount;
            Console.WriteLine($"You have successfully deposited {amount:C}. Your new balance is {balance:C}\n");
        }
        else
        {
            Console.WriteLine("Invalid amount. Please enter a valid positive number.\n");
        }
    }

    static void WithdrawMoney()
    {
        Console.Write("Enter the amount to withdraw: ");
        if (double.TryParse(Console.ReadLine(), out double amount) && amount > 0)
        {
            if (amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"You have successfully withdrawn {amount:C}. Your new balance is {balance:C}\n");
            }
            else
            {
                Console.WriteLine("Sorry, you don't have enough money in your account.\n");
            }
        }
        else
        {
            Console.WriteLine("Invalid amount. Please enter a valid positive number.\n");
        }
    }
}
