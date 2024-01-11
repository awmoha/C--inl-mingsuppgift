using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("This program calculates the minimum number entered by the user.");
        Console.WriteLine("Enter integers, and the program will display the minimum number when you enter 0.");

        int minNumber = int.MaxValue;

        while (true)
        {
            Console.Write("Enter a number (0 to stop): ");
            if (int.TryParse(Console.ReadLine(), out int inputNumber))
            {
                if (inputNumber == 0)
                {
                    break;
                }

                minNumber = Math.Min(minNumber, inputNumber);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }

        Console.WriteLine($"The minimum number you entered is: {minNumber}");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
