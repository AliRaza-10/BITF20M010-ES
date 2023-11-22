using System;
using System.Collections.Generic;
// _______________EXAMPLE 1 ______________ 
// Component
interface IGraphic
{
    void Draw();
}

// Leaf
class Circle : IGraphic
{
    public void Draw()
    {
        Console.WriteLine("Drawing Circle");
    }
}

// Leaf
class Square : IGraphic
{
    public void Draw()
    {
        Console.WriteLine("Example 1 has Drawing Square");
    }
}

// Composite
class CompositeGraphic : IGraphic
{
    private List<IGraphic> graphics = new List<IGraphic>();

    public void Add(IGraphic graphic)
    {
        graphics.Add(graphic);
    }

    public void Draw()
    {
        Console.WriteLine("Drawing Composite Graphic in Example 1");
        foreach (var graphic in graphics)
        {
            graphic.Draw();
        }
    }
}

// __________________EXAMPLE 2 ______________
// Component
interface IFileSystemComponent
{
    void Display();
}

// Leaf
class File : IFileSystemComponent
{
    private string name;

    public File(string name)
    {
        this.name = name;
    }

    public void Display()
    {
        Console.WriteLine($"File: {name}");
    }
}

// Composite
class Directory : IFileSystemComponent
{
    private string name;
    private List<IFileSystemComponent> components = new List<IFileSystemComponent>();

    public Directory(string name)
    {
        this.name = name;
    }

    public void Add(IFileSystemComponent component)
    {
        components.Add(component);
    }

    public void Display()
    {
        Console.WriteLine($"Directory: {name}");
        foreach (var component in components)
        {
            component.Display();
        }
    }
}

// Client code
class Program
{
    static void Main()
    {
        // ___________EXAMPLE 1 ___________
        IGraphic circle = new Circle();
        IGraphic square = new Square();
        CompositeGraphic composite = new CompositeGraphic();
        composite.Add(circle);
        composite.Add(square);
        composite.Draw();
        //_______________EXAMPLE 2 ___________
        IFileSystemComponent file1 = new File("Example2/File1.txt");
        IFileSystemComponent file2 = new File("Example2/File2.txt");
        Directory directory = new Directory("My Documents");
        directory.Add(file1);
        directory.Add(file2);
        Directory rootDirectory = new Directory("C:");
        rootDirectory.Add(directory);
        rootDirectory.Display();
    }
}
