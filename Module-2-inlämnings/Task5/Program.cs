using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Celsius\t\tFahrenheit");

        for (int celsius = -30; celsius <= 50; celsius += 5)
        {
            double fahrenheit = CelsiusToFahrenheit(celsius);
            Console.WriteLine($"{celsius}\t\t{fahrenheit}");
        }
    }

    static double CelsiusToFahrenheit(int celsius)
    {
        return (9.0 / 5.0) * celsius + 32;
    }
}
