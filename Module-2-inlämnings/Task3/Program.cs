using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter the size of a square (2-9): ");
        if (int.TryParse(Console.ReadLine(), out int size) && size >= 2 && size <= 9)
        {
            DisplaySquare(size);
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a value between 2 and 9.");
        }
    }

    static void DisplaySquare(int size)
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }
}
