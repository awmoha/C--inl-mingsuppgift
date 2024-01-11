using System;

class SpaceObject
{
    public virtual void Draw()
    {
        Console.WriteLine("Drawing a generic space object.");
    }
}

class Martian : SpaceObject
{
    public override void Draw()
    {
        Console.WriteLine("Drawing a Martian in red with antennae.");
    }
}

class Venusian : SpaceObject
{
    public override void Draw()
    {
        Console.WriteLine("Drawing a Venusian with unique features.");
    }
}

class Plutonian : SpaceObject
{
    public override void Draw()
    {
        Console.WriteLine("Drawing a Plutonian with distinct characteristics.");
    }
}

class SpaceShip : SpaceObject
{
    public override void Draw()
    {
        Console.WriteLine("Drawing a bright silver flying saucer as a spaceship.");
    }
}

class LaserBeam : SpaceObject
{
    public override void Draw()
    {
        Console.WriteLine("Drawing a bright red laser beam across the screen.");
    }
}

class Program
{
    static void Main()
    {
        // Create an array of type SpaceObject
        SpaceObject[] spaceObjects = new SpaceObject[]
        {
            new Martian(),
            new Venusian(),
            new Plutonian(),
            new SpaceShip(),
            new LaserBeam()
        };

        // Call Draw() for each object and display the result
        foreach (var spaceObject in spaceObjects)
        {
            spaceObject.Draw();
        }
    }
}
