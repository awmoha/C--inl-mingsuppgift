using System;

class Program
{
    static void Main()
 
    {
        while (true)
        {
            Console.WriteLine("Task Menu:");
            Console.WriteLine("1. Task 1");
            Console.WriteLine("2. Task 2");
            Console.WriteLine("3. Task 3");
            Console.WriteLine("4. Task 4");
            Console.WriteLine("5. Task 5");
            Console.WriteLine("6. Task 6");
            Console.WriteLine("7. Task 7");
            Console.WriteLine("8. Task 8");
            Console.WriteLine("0. Exit");

            Console.Write("Enter the task number: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Task1();
                    break;
                case "2":
                    Task2();
                    break;
                case "3":
                    Task3();
                    break;
                case "4":
                    Task4();
                    break;
                case "5":
                    Task5();
                    break;
                case "6":
                    Task6();
                    break;
                case "7":
                    Task7();
                    break;
                case "8":
                    Task8();
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid task number.");
                    break;
            }
        }
    }
    public static void Task1()
    {
        Console.WriteLine("Task 1:");

        string str1, str2;

        // Läs in den första strängen från användaren
        while (true)
        {
            Console.Write("Please enter the first string: ");
            str1 = Console.ReadLine();
            if (!int.TryParse(str1, out _))
            {
                break; // Avsluta loopen om strängen inte kan tolkas som ett heltal
            }
            else
            {
                Console.WriteLine("Please enter a valid string (no numbers).");
            }
        }
        Console.WriteLine("The family name of " + str1 + " is ");

        // Läs in den andra strängen från användaren
        while (true)
        {
            Console.Write("Please enter the second string: ");
            str2 = Console.ReadLine();

            if (!int.TryParse(str2, out _))
            {
                break; // Avsluta loopen om strängen inte kan tolkas som ett heltal
            }
            else
            {
                Console.WriteLine("Please enter a valid string (no numbers).");
            }
        }

        string result = str1 + " " + str2;
        Console.WriteLine($"The result is: The family name of {str1} is {str2}");
        Console.WriteLine();
    }

    public static void Task2()
    {
        Console.WriteLine("Task 2:");
        Console.Write("Enter an integer: ");
        int number = int.Parse(Console.ReadLine());

        if (number % 2 == 0)
            Console.WriteLine("Even");
        else
            Console.WriteLine("Odd");
        Console.WriteLine();
    }

    public static void Task3()
    {
        Console.WriteLine("Task 3:");

        decimal number1, number2, number3;

        while (true)
        {
            Console.Write("Enter the first number 1: ");
            if (decimal.TryParse(Console.ReadLine(), out number1))
            {
                break; 
            }
            else
            {
                Console.WriteLine("Please write a number.");
            }
        }

        while (true)
        {
            Console.Write("Enter the second number 2: ");
            if (decimal.TryParse(Console.ReadLine(), out number2))
            {
                break; 
            }
            else
            {
                Console.WriteLine("Please write a number.");
            }
        }

        while (true)
        {
            Console.Write("Enter the third number 3: ");
            if (decimal.TryParse(Console.ReadLine(), out number3))
            {
                break; 
            }
            else
            {
                Console.WriteLine("Please write a number.");
            }
        }

        // Visa numren i tre kolumner
        Console.WriteLine($"{"Number 1",-15}\t{"Number 2",-15}{"Number 3",-15}");
        Console.Write($"{number1,-15}");
        Console.Write($"{number2,-15}");
        Console.Write($"{number3,-15}");
        Console.WriteLine();
        Console.WriteLine();
    }

    public static void Task4()
    {
        Console.WriteLine("Task 4:");

        Console.WriteLine("Enter your first name: ");
        string firstName = Console.ReadLine();

        Console.WriteLine("Enter your last name: ");
        string lastName = Console.ReadLine();

        Console.WriteLine();

        // Skriv ut initialer som mönster
        PrintInitialPattern(firstName[0]);
        Console.WriteLine();
        PrintInitialPattern(lastName[0]);

        Console.WriteLine();
    }

    // Funktion för att skriva ut initialer som mönster
    public static void PrintInitialPattern(char initial)
    {
        Console.WriteLine($"    {initial}  ");
        Console.WriteLine($"  {initial}   {initial}  ");
        Console.WriteLine($"{initial}        {initial}");
        Console.WriteLine($"  {new string(initial, 5)}  ");
        Console.WriteLine($"    {new string(initial, 1)}");
        Console.WriteLine($"  {new string(initial, 5)}");
    }

    public static void Task5()
    {
        Console.WriteLine("Task 5:");

        int x, y;

        while (true)
        {
            Console.Write("Enter the first number: ");
            string inputX = Console.ReadLine();

            if (int.TryParse(inputX, out x))
            {
                break; 
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }

        while (true)
        {
            Console.Write("Enter the second number: ");
            string inputY = Console.ReadLine();

            if (int.TryParse(inputY, out y))
            {
                break; 
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }

        Console.WriteLine($"The sum of x[{x}] and y[{y}] is {x + y}");
        Console.WriteLine($"The difference of x[{x}] and y[{y}] is {x - y}");
        Console.WriteLine($"The product of x[{x}] and y[{y}] is {x * y}");
        Console.WriteLine($"The division of x[{x}] by y[{y}] is {x / (float)y}");
        Console.WriteLine($"The remainder of x[{x}] divided by y[{y}] is {x % y}");
        Console.WriteLine();
    }


    public static void Task6()
    {
        Console.WriteLine("Task 6:");

        int radius;

        while (true)
        {
            Console.Write("Enter the radius of a circle: ");
            string inputRadius = Console.ReadLine();

            if (int.TryParse(inputRadius, out radius) && radius > 0)
            {
                break; 
            }
            else
            {
                Console.WriteLine("Please enter a valid positive number for the radius.");
            }
        }

        double diameter = 2 * radius;
        double circumference = 2 * Math.PI * radius;
        double area = Math.PI * radius * radius;

        Console.WriteLine($"Diameter: {diameter}");
        Console.WriteLine($"Circumference: {circumference}");
        Console.WriteLine($"Area: {area}");
        Console.WriteLine();
    }


    public static void Task7()
    {
        Console.WriteLine("Task 7:");

        decimal number;

        while (true)
        {
            Console.Write("Enter a four-digit decimal number: ");
            string inputNumber = Console.ReadLine();

            if (decimal.TryParse(inputNumber, out number) && inputNumber.Length == 4)
            {
                break; 
            }
            else
            {
                Console.WriteLine("Please enter a valid four-digit decimal number.");
            }
        }

        int thousands = (int)(number / 1000);
        int hundreds = (int)((number / 100) % 10);
        int tens = (int)((number / 10) % 10);
        int units = (int)(number % 10);

        Console.WriteLine($"Digits separated by tabs: {thousands}\t{hundreds}\t{tens}\t{units}");
        Console.WriteLine();
    }

    public static void Task8()
    {
        Console.WriteLine("Task 8:");

        decimal number;

        while (true)
        {
            Console.Write("Enter an integer: ");
            string inputNumber = Console.ReadLine();

            if (decimal.TryParse(inputNumber, out number))
            {
                if (Math.Floor(number) == number) 
                {
                    break; 
                }
            }

            Console.WriteLine("Please enter a valid integer.");
        }

        Console.WriteLine($"Square of the number: {number * number}");
        Console.WriteLine($"Cube of the number: {number * number * number}");
        Console.WriteLine();
    }

}
