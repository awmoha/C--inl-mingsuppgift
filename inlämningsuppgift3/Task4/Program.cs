using System;

class HeartRates
{
    private string firstName;
    private string lastName;
    private int yearOfBirth;
    private int currentYear;

    // Constructor
    public HeartRates(string firstName, string lastName, int yearOfBirth, int currentYear)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.yearOfBirth = yearOfBirth;
        this.currentYear = currentYear;
    }

    // Properties
    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }

    public int YearOfBirth
    {
        get { return yearOfBirth; }
        set { yearOfBirth = value; }
    }

    public int CurrentYear
    {
        get { return currentYear; }
        set { currentYear = value; }
    }

    // Method to calculate and return person's age
    public int CalculateAge()
    {
        return currentYear - yearOfBirth;
    }

    // Method to calculate and return person's maximum heart rate
    public int CalculateMaxHeartRate()
    {
        return 220 - CalculateAge();
    }

    // Method to calculate and return person's minimum target heart rate
    public int CalculateMinTargetHeartRate()
    {
        return (int)(0.5 * CalculateMaxHeartRate());
    }

    // Method to calculate and return person's maximum target heart rate
    public int CalculateMaxTargetHeartRate()
    {
        return (int)(0.85 * CalculateMaxHeartRate());
    }
}

class Program
{
    static void Main()
    {
        // Prompt for user information
        Console.Write("Enter your first name: ");
        string firstName = Console.ReadLine();

        Console.Write("Enter your last name: ");
        string lastName = Console.ReadLine();

        Console.Write("Enter your year of birth: ");
        int yearOfBirth = int.Parse(Console.ReadLine());

        Console.Write("Enter the current year: ");
        int currentYear = int.Parse(Console.ReadLine());

        // Instantiate an object of class HeartRates
        HeartRates personHeartRates = new HeartRates(firstName, lastName, yearOfBirth, currentYear);

        // Display information
        Console.WriteLine($"\nInformation for {personHeartRates.FirstName} {personHeartRates.LastName}:");
        Console.WriteLine($"Year of Birth: {personHeartRates.YearOfBirth}");
        Console.WriteLine($"Age: {personHeartRates.CalculateAge()} years");
        Console.WriteLine($"Maximum Heart Rate: {personHeartRates.CalculateMaxHeartRate()} beats per minute");
        Console.WriteLine($"Target Heart Rate Range: {personHeartRates.CalculateMinTargetHeartRate()}-{personHeartRates.CalculateMaxTargetHeartRate()} beats per minute");
    }
}
