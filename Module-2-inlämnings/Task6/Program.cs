using System;

class Program
{
    static void Main()
    {
        char grade;

        while (true)
        {
            Console.Write("Enter your grade (A to F) or 'G' to end: ");
            string input = Console.ReadLine();

            if (input.Length == 1 && char.TryParse(input, out grade))
            {
                if (grade == 'G')
                {
                    Console.WriteLine("Program ended. Goodbye!");
                    break;
                }

                DisplayGradeDefinition(grade);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a single letter (A to F) or 'G' to end.");
            }
        }
    }

    static void DisplayGradeDefinition(char grade)
    {
        switch (char.ToUpper(grade))
        {
            case 'A':
                Console.WriteLine("Excellent – outstanding performance with only minor errors");
                break;
            case 'B':
                Console.WriteLine("Very good – above the average standard but with some errors");
                break;
            case 'C':
                Console.WriteLine("Good – generally sound work with a number of notable errors");
                break;
            case 'D':
                Console.WriteLine("Satisfactory – fair but with significant shortcomings");
                break;
            case 'E':
                Console.WriteLine("Sufficient – performance meets the minimum criteria");
                break;
            case 'F':
                Console.WriteLine("Fail – some more work required before the credit can be awarded");
                break;
            default:
                Console.WriteLine("Invalid grade. Please enter a valid grade (A to F) or 'G' to end.");
                break;
        }
    }
}
