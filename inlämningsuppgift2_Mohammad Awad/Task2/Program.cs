using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a numeric value for the radius: ");
        if (double.TryParse(Console.ReadLine(), out double radius) && radius > 0)
        {
            CalculateAndDisplayVolumes(radius);
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid positive numeric value for the radius.");
        }
    }

    static void CalculateAndDisplayVolumes(double maxRadius)
    {
        Console.WriteLine("Sphere's volume with radius:");

        for (int i = 1; i <= maxRadius; i++)
        {
            double volume = CalculateSphereVolume(i);
            Console.WriteLine($"Radius {i}: {volume:F2}");
        }
    }

    static double CalculateSphereVolume(double radius)
    {
        const double pi = Math.PI;
        return (4.0 / 3.0) * pi * Math.Pow(radius, 3);
    }
}
