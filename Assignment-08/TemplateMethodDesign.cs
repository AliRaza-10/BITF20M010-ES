using System;
// __________________EXAMPLE 1________
abstract class CaffeineBeverage
{
    // The template method that defines the algorithm
    public void PrepareRecipe()
    {
        BoilWater();
        Brew();
        PourInCup();
        AddCondiments();
    }

    // Abstract methods to be implemented by subclasses
    protected abstract void Brew();
    protected abstract void AddCondiments();

    // Common methods used in the algorithm
    private void BoilWater()
    {
        Console.WriteLine("Boiling water");
    }

    private void PourInCup()
    {
        Console.WriteLine("Pouring into cup");
    }
}

class Coffee : CaffeineBeverage
{
    protected override void Brew()
    {
        Console.WriteLine("Brewing coffee grounds");
    }

    protected override void AddCondiments()
    {
        Console.WriteLine("Adding sugar and milk");
    }
}

class Tea : CaffeineBeverage
{
    protected override void Brew()
    {
        Console.WriteLine("Steeping the tea");
    }

    protected override void AddCondiments()
    {
        Console.WriteLine("Adding lemon");
    }
}
// __________________EXAMPLE 2________
abstract class Document
{
    // The template method that defines the algorithm
    public void PrintDocument()
    {
        FormatHeader();
        PrintBody();
        FormatFooter();
    }

    // Abstract methods to be implemented by subclasses
    protected abstract void FormatHeader();
    protected abstract void PrintBody();
    protected abstract void FormatFooter();
}

class Resume : Document
{
    protected override void FormatHeader()
    {
        Console.WriteLine("Resume Header");
    }

    protected override void PrintBody()
    {
        Console.WriteLine("Resume Body");
    }

    protected override void FormatFooter()
    {
        Console.WriteLine("Resume Footer");
    }
}

class Letter : Document
{
    protected override void FormatHeader()
    {
        Console.WriteLine("Letter Header");
    }

    protected override void PrintBody()
    {
        Console.WriteLine("Letter Body");
    }

    protected override void FormatFooter()
    {
        Console.WriteLine("Letter Footer");
    }
}


class Program
{
    static void Main()
    {
        //__________________EXAMPLE 1________
        CaffeineBeverage coffee = new Coffee();
        coffee.PrepareRecipe();
        CaffeineBeverage tea = new Tea();
        tea.PrepareRecipe();
         Console.WriteLine();
        //______________EXAMPLE 2 _____
        Document resume = new Resume();
        resume.PrintDocument();
        Document letter = new Letter();
        letter.PrintDocument();
    }
}
