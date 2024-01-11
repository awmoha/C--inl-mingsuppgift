using System;

abstract class Employee
{
    public string FirstName { get; }
    public string LastName { get; }
    public string SSN { get; }

    public Employee(string firstName, string lastName, string ssn)
    {
        FirstName = firstName;
        LastName = lastName;
        SSN = ssn;
    }

    public override string ToString()
    {
        return $"Name: {FirstName} {LastName}, SSN: {SSN}";
    }

    public abstract decimal Earning();
}

class SalariedEmployee : Employee
{
    public decimal WeeklySalary { get; }

    public SalariedEmployee(string firstName, string lastName, string ssn, decimal weeklySalary)
        : base(firstName, lastName, ssn)
    {
        WeeklySalary = weeklySalary;
    }

    public override decimal Earning()
    {
        return WeeklySalary;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Weekly Salary: {WeeklySalary:C}";
    }
}

class HourlyEmployee : Employee
{
    public int Hours { get; }
    public decimal Wage { get; }

    public HourlyEmployee(string firstName, string lastName, string ssn, int hours, decimal wage)
        : base(firstName, lastName, ssn)
    {
        Hours = hours;
        Wage = wage;
    }

    public override decimal Earning()
    {
        return Hours * Wage;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Hours Worked: {Hours}, Wage per Hour: {Wage:C}";
    }
}

class Program
{
    static void Main()
    {
        SalariedEmployee salariedEmployee = new SalariedEmployee("Moha", "Awad", "123-45-6789", 1000.00m);
        HourlyEmployee hourlyEmployee = new HourlyEmployee("Baba", "Vos", "987-65-4321", 40, 20.00m);

        Console.WriteLine(salariedEmployee.ToString());
        Console.WriteLine($"Earnings: {salariedEmployee.Earning():C}");

        Console.WriteLine(hourlyEmployee.ToString());
        Console.WriteLine($"Earnings: {hourlyEmployee.Earning():C}");
    }
}
