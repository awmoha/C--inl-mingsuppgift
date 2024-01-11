using System;

class Program
{
    static void Main()
    {
        // Integer sum
        int num1 = GetIntegerInput("Enter an integer and press Enter key:");
        int num2 = GetIntegerInput("Enter another integer and press Enter key:");
        int sumInt = AddNumbers(num1, num2);
        Console.WriteLine($"The sum of two integers is: {sumInt}");

        // Float sum
        float float1 = GetFloatInput("Enter a float number and press Enter key:");
        float float2 = GetFloatInput("Enter another float number and press Enter key:");
        float sumFloat = AddNumbers(float1, float2);
        Console.WriteLine($"The sum of two float numbers is: {sumFloat}");

        // String concatenation
        string lastName = GetStringInput("Enter your last name and press Enter key:");
        string firstName = GetStringInput("Enter your first name and press Enter key:");
        string fullName = ConcatenateStrings(firstName, lastName);
        Console.WriteLine($"Your name is: {fullName}");

        // Complex number sum
        int real1 = GetIntegerInput("Enter the real part of the first complex number and press Enter key:");
        int imaginary1 = GetIntegerInput("Enter the imaginary part of the first complex number and press Enter key:");
        int real2 = GetIntegerInput("Enter the real part of the second complex number and press Enter key:");
        int imaginary2 = GetIntegerInput("Enter the imaginary part of the second complex number and press Enter key:");
        string complexSum = AddComplexNumbers(real1, imaginary1, real2, imaginary2);
        Console.WriteLine($"The sum of two complex numbers is: {complexSum}");
    }

    static int GetIntegerInput(string message)
    {
        Console.WriteLine(message);
        return int.Parse(Console.ReadLine());
    }

    static float GetFloatInput(string message)
    {
        Console.WriteLine(message);
        return float.Parse(Console.ReadLine());
    }

    static string GetStringInput(string message)
    {
        Console.WriteLine(message);
        return Console.ReadLine();
    }

    // Overloaded methods
    static int AddNumbers(int a, int b)
    {
        return a + b;
    }

    static float AddNumbers(float a, float b)
    {
        return a + b;
    }

    static string ConcatenateStrings(string firstName, string lastName)
    {
        return firstName + " " + lastName;
    }

    static string AddComplexNumbers(int real1, int imaginary1, int real2, int imaginary2)
    {
        int sumReal = real1 + real2;
        int sumImaginary = imaginary1 + imaginary2;
        return $"{sumReal} + i{sumImaginary}";
    }
}
