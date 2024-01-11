using System;

class Shape
{
    protected int x, y;

    public Shape(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public virtual string Display()
    {
        return $"Coordinates: ({x}, {y})";
    }
}

class Circle : Shape
{
    protected double radius;

    public Circle(int x, int y, double radius) : base(x, y)
    {
        this.radius = radius;
    }

    public override string Display()
    {
        double area = Math.PI * Math.Pow(radius, 2);
        return $"Coordinates: ({x}, {y}), Area: {area}";
    }
}

class Cylinder : Circle
{
    protected double height;

    public Cylinder(int x, int y, double radius, double height) : base(x, y, radius)
    {
        this.height = height;
    }

    public override string Display()
    {
        double area = (2 * Math.PI * Math.Pow(radius, 2)) + (2 * Math.PI * radius * height);
        double volume = Math.PI * Math.Pow(radius, 2) * height;

        return $"Coordinates: ({x}, {y}), Area: {area}, Volume: {volume}";
    }
}

class Program
{
    static void Main()
    {
        // Example usage
        Shape shape = new Shape(1, 2);
        Console.WriteLine(shape.Display());

        Circle circle = new Circle(3, 4, 5);
        Console.WriteLine(circle.Display());

        Cylinder cylinder = new Cylinder(6, 7, 8, 9);
        Console.WriteLine(cylinder.Display());
    }
}
