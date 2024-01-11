using System;

class Bicycle
{
    private static int Bicycle_Id = 1000; // Static variable to keep track of the Bicycle ID
    private int id; // Instance variable to store the Bicycle ID
    private int speed; // Instance variable to store the speed of the Bicycle
    private string model; // Instance variable to store the model of the Bicycle

    // Constructor to initialize the Bicycle object
    public Bicycle()
    {
        id = ++Bicycle_Id; // Increment the Bicycle ID for each new object
        speed = 0; // Initialize speed to zero
        model = "MyFavoriteModel"; // Initialize model to a default value
    }

    // Property to read and modify the speed
    public int Speed
    {
        get { return speed; }
        set
        {
            // Ensure speed is not below zero or above 100
            speed = Math.Max(0, Math.Min(100, value));
        }
    }

    // Read-only property to only read the model
    public string Model
    {
        get { return model; }
    }

    // Method to accelerate the Bicycle
    public void Accelerate()
    {
        if (speed < 100)
        {
            speed += 5;
        }
        else
        {
            Console.WriteLine("The speed cannot be increased beyond 100.");
        }
    }

    // Method to brake the Bicycle
    public void Brake()
    {
        if (speed > 0)
        {
            speed -= 5;
        }
        else
        {
            Console.WriteLine("The speed cannot be decreased below 0.");
        }
    }

    // Method to display information about the Bicycle
    public void DisplayInfo()
    {
        Console.WriteLine($"Bicycle ID: {id}");
        Console.WriteLine($"Model: {Model}");
        Console.WriteLine($"Speed: {Speed}\n");
    }
}

class Program
{
    static void Main()
    {
        // Test the Bicycle class

        Bicycle bike1 = new Bicycle();
        bike1.Accelerate();
        bike1.DisplayInfo();

        Bicycle bike2 = new Bicycle();
        bike2.Brake();
        bike2.DisplayInfo();

        Bicycle bike3 = new Bicycle();
        bike3.Accelerate();
        bike3.Accelerate();
        bike3.DisplayInfo();
    }
}
