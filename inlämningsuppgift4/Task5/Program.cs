using System;

class Program
{
    static void Main()
    {
        int[] grades = GenerateRandomGrades(10);

        for (int i = 0; i < grades.Length; i++)
        {
            Console.WriteLine($"Student {i + 1} has got {grades[i]}: {GenerateHistogram(grades[i])}");
        }
    }

    static int[] GenerateRandomGrades(int count)
    {
        Random random = new Random();
        int[] grades = new int[count];

        for (int i = 0; i < count; i++)
        {
            // Generating random grades between 1 and 10
            grades[i] = random.Next(1, 11);
        }

        return grades;
    }

    static string GenerateHistogram(int count)
    {
        // Generating a histogram using '*' character
        return new string('*', count);
    }
}
