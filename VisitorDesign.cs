using System;
using System.Collections.Generic;
// ______________EXAMPLE 1______________
// Element interface
interface IShape
{
    void Accept(IVisitor visitor);
}

// Concrete Elements
class Circle : IShape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public void Accept(IVisitor visitor)
    {
        visitor.VisitCircle(this);
    }
}

class Square : IShape
{
    public double SideLength { get; set; }

    public Square(double sideLength)
    {
        SideLength = sideLength;
    }

    public void Accept(IVisitor visitor)
    {
        visitor.VisitSquare(this);
    }
}

// Visitor interface
interface IVisitor
{
    void VisitCircle(Circle circle);
    void VisitSquare(Square square);
}

// Concrete Visitor
class AreaVisitor : IVisitor
{
    public void VisitCircle(Circle circle)
    {
        double area = Math.PI * Math.Pow(circle.Radius, 2);
        Console.WriteLine($"Area of circle with radius {circle.Radius}: {area}");
    }

    public void VisitSquare(Square square)
    {
        double area = Math.Pow(square.SideLength, 2);
        Console.WriteLine($"Area of square with side length {square.SideLength}: {area}");
    }
}

// ______________EXAMPLE 2______________

// Element interface
interface IComputerComponent
{
    void Accept(IComputerVisitor visitor);
}

// Concrete Elements
class CPU : IComputerComponent
{
    public string Model { get; set; }

    public CPU(string model)
    {
        Model = model;
    }

    public void Accept(IComputerVisitor visitor)
    {
        visitor.VisitCPU(this);
    }
}

class GPU : IComputerComponent
{
    public string Model { get; set; }

    public GPU(string model)
    {
        Model = model;
    }

    public void Accept(IComputerVisitor visitor)
    {
        visitor.VisitGPU(this);
    }
}

class RAM : IComputerComponent
{
    public int SizeGB { get; set; }

    public RAM(int sizeGB)
    {
        SizeGB = sizeGB;
    }

    public void Accept(IComputerVisitor visitor)
    {
        visitor.VisitRAM(this);
    }
}

// Visitor interface
interface IComputerVisitor
{
    void VisitCPU(CPU cpu);
    void VisitGPU(GPU gpu);
    void VisitRAM(RAM ram);
}

// Concrete Visitor
class SpecificationVisitor : IComputerVisitor
{
    public void VisitCPU(CPU cpu)
    {
        Console.WriteLine($"CPU Model: {cpu.Model}");
    }

    public void VisitGPU(GPU gpu)
    {
        Console.WriteLine($"GPU Model: {gpu.Model}");
    }

    public void VisitRAM(RAM ram)
    {
        Console.WriteLine($"RAM Size: {ram.SizeGB} GB");
    }
}

// Client
class Computer
{
    private List<IComputerComponent> components = new List<IComputerComponent>();

    public void AddComponent(IComputerComponent component)
    {
        components.Add(component);
    }

    public void AcceptVisitor(IComputerVisitor visitor)
    {
        foreach (var component in components)
        {
            component.Accept(visitor);
        }
    }
}


// Client
class Program
{
    // ______________EXAMPLE 1______________
    static void Main()
    {
        List<IShape> shapes = new List<IShape>
        {
            new Circle(5),
            new Square(4),
            new Circle(3)
        };

        IVisitor areaVisitor = new AreaVisitor();

        foreach (var shape in shapes)
        {
            shape.Accept(areaVisitor);
        }
        Console.WriteLine();
    // ______________EXAMPLE 2______________
        Computer myComputer = new Computer();
        myComputer.AddComponent(new CPU("Intel Core i7"));
        myComputer.AddComponent(new GPU("NVIDIA GeForce RTX 3080"));
        myComputer.AddComponent(new RAM(16));
        IComputerVisitor specVisitor = new SpecificationVisitor();
        myComputer.AcceptVisitor(specVisitor);
    }
    
}
