using System;
// __________EXAMPLE 1__________
// Prototype Interface
public interface ICloneableStudent
{
    ICloneableStudent Clone();
}

// Concrete Prototype: Student
public class Student : ICloneableStudent
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Major { get; set; }

    // Constructor
    public Student(string name, int age, string major)
    {
        Name = name;
        Age = age;
        Major = major;
    }

    // Clone method to create a copy
    public ICloneableStudent Clone()
    {
        return (ICloneableStudent)MemberwiseClone();
    }

    public void Display()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}, Major: {Major}");
    }
}

//________EXAMPLE 2__________
// Prototype Interface
public interface ICloneableBird
{
    ICloneableBird Clone();
    void Display();
}

// Concrete Prototype: Eagle
public class Eagle : ICloneableBird
{
    public string Name { get; set; }
    public double Wingspan { get; set; }

    // Constructor
    public Eagle(string name, double wingspan)
    {
        Name = name;
        Wingspan = wingspan;
    }

    // Clone method to create a copy
    public ICloneableBird Clone()
    {
        return new Eagle(Name, Wingspan);
    }

    public void Display()
    {
        Console.WriteLine($"Eagle Name: {Name}, Wingspan: {Wingspan} inches");
    }
}

// Concrete Prototype: Penguin
public class Penguin : ICloneableBird
{
    public string Name { get; set; }
    public string Color { get; set; }

    // Constructor
    public Penguin(string name, string color)
    {
        Name = name;
        Color = color;
    }

    // Clone method to create a copy
    public ICloneableBird Clone()
    {
        return new Penguin(Name, Color);
    }

    public void Display()
    {
        Console.WriteLine($"Penguin Name: {Name}, Color: {Color}");
    }
}
class Program
{
    static void Main()
    {
        // __________EXAMPLE 1__________
        // Original student
        Student originalStudent = new Student("Ali", 10, "Information Technology");
        Console.WriteLine("Original Student:");
        originalStudent.Display();
        // Creating a copy of the original student
        Student clonedStudent = (Student)originalStudent.Clone();
        Console.WriteLine("\nCloned Student:");
        clonedStudent.Display();
        // __________EXAMPLE 2__________
        // Original eagle
        Console.WriteLine();
        ICloneableBird originalEagle = new Eagle("Aquila", 72.5);
        Console.WriteLine("Original Eagle:");
        originalEagle.Display();
        // Creating a copy of eagle 
        ICloneableBird clonedEagle = originalEagle.Clone();
        Console.WriteLine("\nCloned Eagle:");
        clonedEagle.Display();
        // Original penguin
        ICloneableBird originalPenguin = new Penguin("Chilly", "Black and White");
        Console.WriteLine("\nOriginal Penguin:");
        originalPenguin.Display();
        // Creating a copy of penguin 
        ICloneableBird clonedPenguin = originalPenguin.Clone();
        Console.WriteLine("\nCloned Penguin:");
        clonedPenguin.Display(); 
    }
}
