using System;

// Part A
interface IPayable
{
    decimal GetPaymentAmount();
}

class Invoice : IPayable
{
    private string invoiceNumber;
    private int quantity;
    private decimal pricePerItem;

    public Invoice(string invoiceNumber, int quantity, decimal pricePerItem)
    {
        this.invoiceNumber = invoiceNumber;
        this.quantity = quantity;
        this.pricePerItem = pricePerItem;
    }

    public decimal GetPaymentAmount()
    {
        return quantity * pricePerItem;
    }
}

// Part B
class Employee : IPayable
{
    protected string FirstName { get; }
    protected string LastName { get; }
    protected string SSN { get; }

    public Employee(string firstName, string lastName, string ssn)
    {
        FirstName = firstName;
        LastName = lastName;
        SSN = ssn;
    }

    public virtual decimal GetPaymentAmount()
    {
        // Default implementation, can be overridden in derived classes
        return 0.0m;
    }
}

class SalariedEmployee : Employee
{
    private decimal WeeklySalary { get; }

    public SalariedEmployee(string firstName, string lastName, string ssn, decimal weeklySalary)
        : base(firstName, lastName, ssn)
    {
        WeeklySalary = weeklySalary;
    }

    public override decimal GetPaymentAmount()
    {
        return WeeklySalary;
    }
}
class HourlyEmployee : Employee
{
    private int Hours { get; }
    private decimal Wage { get; }

    public HourlyEmployee(string firstName, string lastName, string ssn, int hours, decimal wage)
        : base(firstName, lastName, ssn)
    {
        Hours = hours;
        Wage = wage;
    }

    public override decimal GetPaymentAmount()
    {
        return Hours * Wage;
    }
}


class Program
{
    static void Main()
    {
        // Part A
        Invoice invoice1 = new Invoice("INV001", 5, 10.0m);
        Invoice invoice2 = new Invoice("INV002", 3, 15.5m);

        Console.WriteLine("Part A: Invoices Payment Amounts");
        Console.WriteLine($"Invoice 1 Payment Amount: {invoice1.GetPaymentAmount():C}");
        Console.WriteLine($"Invoice 2 Payment Amount: {invoice2.GetPaymentAmount():C}");

        // Part B
        Employee employee1 = new SalariedEmployee("John", "Doe", "123-45-6789", 1000.00m);
        Employee employee2 = new HourlyEmployee("Jane", "Smith", "987-65-4321", 40, 20.00m);

        IPayable[] payables = { invoice1, invoice2, employee1, employee2 };

        Console.WriteLine("\nPart B: Employees and Invoices Payment Amounts");
        foreach (var payable in payables)
        {
            Console.WriteLine($"Payment Amount: {payable.GetPaymentAmount():C}");
        }
    }
}
