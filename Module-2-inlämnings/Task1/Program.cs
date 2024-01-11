using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Number\tSquare\tCubic");

        for (int i = 1; i <= 100; i++)
        {
            int square = i * i;
            int cubic = i * i * i;

            Console.WriteLine($"{i}\t{square}\t{cubic}");
        }
    }
}
