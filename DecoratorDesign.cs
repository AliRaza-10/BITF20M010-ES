using System;
//________________________EXAMPLE 1________________________
// Component
interface ICoffee
{
    string GetDescription();
    double GetCost();
}

// Concrete Component
class SimpleCoffee : ICoffee
{
    public string GetDescription()
    {
        return "Simple Coffee";
    }

    public double GetCost()
    {
        return 2.0;
    }
}

// Decorator
abstract class CoffeeDecorator : ICoffee
{
    protected ICoffee coffee;

    protected CoffeeDecorator(ICoffee coffee)
    {
        this.coffee = coffee;
    }

    public virtual string GetDescription()
    {
        return coffee.GetDescription();
    }

    public virtual double GetCost()
    {
        return coffee.GetCost();
    }
}

// Concrete Decorator 1
class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(ICoffee coffee) : base(coffee)
    {
    }

    public override string GetDescription()
    {
        return $"{base.GetDescription()}, with Milk";
    }

    public override double GetCost()
    {
        return base.GetCost() + 0.5;
    }
}

// Concrete Decorator 2
class SugarDecorator : CoffeeDecorator
{
    public SugarDecorator(ICoffee coffee) : base(coffee)
    {
    }

    public override string GetDescription()
    {
        return $"{base.GetDescription()}, with Sugar";
    }

    public override double GetCost()
    {
        return base.GetCost() + 0.2;
    }
}
// ________________________EXAMPLE 2________________________

// Component
interface IText
{
    string GetText();
}

// Concrete Component
class PlainText : IText
{
    private string text;

    public PlainText(string text)
    {
        this.text = text;
    }

    public string GetText()
    {
        return text;
    }
}

// Decorator
abstract class TextDecorator : IText
{
    protected IText text;

    protected TextDecorator(IText text)
    {
        this.text = text;
    }

    public virtual string GetText()
    {
        return text.GetText();
    }
}

// Concrete Decorator 1
class BoldTextDecorator : TextDecorator
{
    public BoldTextDecorator(IText text) : base(text)
    {
    }

    public override string GetText()
    {
        return $"<b>{base.GetText()}</b>";
    }
}

// Concrete Decorator 2
class ItalicTextDecorator : TextDecorator
{
    public ItalicTextDecorator(IText text) : base(text)
    {
    }

    public override string GetText()
    {
        return $"<i>{base.GetText()}</i>";
    }
}

// Client code
class Program
{
    static void Main()
    {
        //________________________EXAMPLE 1________________________
        ICoffee simpleCoffee = new SimpleCoffee();
        Console.WriteLine($"Cost: {simpleCoffee.GetCost()}, Description: {simpleCoffee.GetDescription()}");
        ICoffee milkCoffee = new MilkDecorator(simpleCoffee);
        Console.WriteLine($"Cost: {milkCoffee.GetCost()}, Description: {milkCoffee.GetDescription()}");
        ICoffee sweetMilkCoffee = new SugarDecorator(milkCoffee);
        Console.WriteLine($"Cost: {sweetMilkCoffee.GetCost()}, Description: {sweetMilkCoffee.GetDescription()}");
        //________________________EXAMPLE 2________________________
        IText plainText = new PlainText("Hello, Decorator Pattern!");
        Console.WriteLine($"Text: {plainText.GetText()}");
        IText boldText = new BoldTextDecorator(plainText);
        Console.WriteLine($"Text: {boldText.GetText()}");
        IText italicBoldText = new ItalicTextDecorator(boldText);
        Console.WriteLine($"Text: {italicBoldText.GetText()}");
    }
}
