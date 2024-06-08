using System;

class Program
{
    static void Main()
    {
        double initialPopulation = 6.5; // in billion
        double growthRate = 1.4 / 100;  // converting percentage to decimal
        double targetPopulation = 10.0; // in billion

        int year = 0;
        double currentPopulation = initialPopulation;

        while (currentPopulation <= targetPopulation)
        {
            currentPopulation *= (1 + growthRate);
            year++;
        }

        Console.WriteLine($"The world population will exceed {targetPopulation} billion in the year {DateTime.Now.Year + year}.");
    }
}
