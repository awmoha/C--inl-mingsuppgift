using System;

class Sphere
{
    // Private field representing the radius of the sphere
    private int radius;

    // Default constructor
    public Sphere()
    {
        radius = 0;
    }

    // Constructor with parameter to set the radius
    public Sphere(int initialRadius)
    {
        // Use the property to ensure validation
        Radius = initialRadius;
    }

    // Property to allow modification of the radius with validation
    public int Radius
    {
        get { return radius; }
        set
        {
            // Validate the input value
            if (value < 0)
            {
                radius = 0; // Set radius to zero for negative values
            }
            else
            {
                radius = value;
            }
        }
    }

    // Method to calculate the volume of the sphere
    public double CalculateVolume()
    {
        return (4.0 / 3.0) * Math.PI * Math.Pow(radius, 3);
    }

    // Method to calculate the surface area of the sphere
    public double CalculateSurfaceArea()
    {
        return 4.0 * Math.PI * Math.Pow(radius, 2);
    }
}

class Program
{
    static void Main()
    {
        // Test the Sphere class

        // Create a sphere with default constructor
        Sphere sphere1 = new Sphere();
        Console.WriteLine($"Initial Radius: {sphere1.Radius}");

        // Modify the radius using the property
        sphere1.Radius = 5;
        Console.WriteLine($"Modified Radius: {sphere1.Radius}");

        // Calculate and print volume and surface area
        Console.WriteLine($"Volume: {sphere1.CalculateVolume()}");
        Console.WriteLine($"Surface Area: {sphere1.CalculateSurfaceArea()}");

        // Create another sphere with a parameterized constructor
        Sphere sphere2 = new Sphere(3);
        Console.WriteLine($"Initial Radius: {sphere2.Radius}");

        // Modify the radius using the property
        sphere2.Radius = -2; // Testing negative value validation
        Console.WriteLine($"Modified Radius: {sphere2.Radius}");

        // Calculate and print volume and surface area
        Console.WriteLine($"Volume: {sphere2.CalculateVolume()}");
        Console.WriteLine($"Surface Area: {sphere2.CalculateSurfaceArea()}");
    }
}
