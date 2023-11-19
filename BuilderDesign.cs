using System;
// ____EAXMPLE 1________________
// Product: Meal
public class Meal
{
    public string MainCourse { get; set; }
    public string Drink { get; set; }
    public string Dessert { get; set; }

    public void Display()
    {
        Console.WriteLine($"Main Course: {MainCourse}, Drink: {Drink}, Dessert: {Dessert}");
    }
}

// Builder Interface
public interface IMealBuilder
{
    void BuildMainCourse();
    void BuildDrink();
    void BuildDessert();
    Meal GetMeal();
}

// Concrete Builder for Healthy Meal
public class HealthyMealBuilder : IMealBuilder
{
    private Meal meal = new Meal();

    public void BuildMainCourse()
    {
        meal.MainCourse = "Grilled Chicken Salad";
    }

    public void BuildDrink()
    {
        meal.Drink = "Water";
    }

    public void BuildDessert()
    {
        meal.Dessert = "Fruit Salad";
    }

    public Meal GetMeal()
    {
        return meal;
    }
}

// Concrete Builder for Fast Food Meal
public class FastFoodMealBuilder : IMealBuilder
{
    private Meal meal = new Meal();

    public void BuildMainCourse()
    {
        meal.MainCourse = "Cheeseburger";
    }

    public void BuildDrink()
    {
        meal.Drink = "Cola";
    }

    public void BuildDessert()
    {
        meal.Dessert = "Ice Cream";
    }

    public Meal GetMeal()
    {
        return meal;
    }
}

// Director
public class MealDirector
{
    public void Construct(IMealBuilder builder)
    {
        builder.BuildMainCourse();
        builder.BuildDrink();
        builder.BuildDessert();
    }
}

// ____EAXMPLE 2________________
// Product: Computer
public class Computer
{
    public string Processor { get; set; }
    public int RAM { get; set; }
    public int Storage { get; set; }
    public string GraphicsCard { get; set; }

    public void Display()
    {
        Console.WriteLine($"Processor: {Processor}, RAM: {RAM}GB, Storage: {Storage}GB, Graphics Card: {GraphicsCard}");
    }
}

// Builder Interface
public interface IComputerBuilder
{
    void BuildProcessor();
    void BuildRAM();
    void BuildStorage();
    void BuildGraphicsCard();
    Computer GetComputer();
}

// Concrete Builder for Basic Computer
public class BasicComputerBuilder : IComputerBuilder
{
    private Computer computer = new Computer();

    public void BuildProcessor()
    {
        computer.Processor = "Intel Core i3";
    }

    public void BuildRAM()
    {
        computer.RAM = 4;
    }

    public void BuildStorage()
    {
        computer.Storage = 256;
    }

    public void BuildGraphicsCard()
    {
        computer.GraphicsCard = "Integrated Graphics";
    }

    public Computer GetComputer()
    {
        return computer;
    }
}

// Concrete Builder for Gaming Computer
public class GamingComputerBuilder : IComputerBuilder
{
    private Computer computer = new Computer();

    public void BuildProcessor()
    {
        computer.Processor = "Intel Core i7";
    }

    public void BuildRAM()
    {
        computer.RAM = 16;
    }

    public void BuildStorage()
    {
        computer.Storage = 512;
    }

    public void BuildGraphicsCard()
    {
        computer.GraphicsCard = "NVIDIA GeForce RTX 3060";
    }

    public Computer GetComputer()
    {
        return computer;
    }
}

// Director
public class ComputerDirector
{
    public void Construct(IComputerBuilder builder)
    {
        builder.BuildProcessor();
        builder.BuildRAM();
        builder.BuildStorage();
        builder.BuildGraphicsCard();
    }
}


class Program
{
    static void Main()
    {
        // ____EAXMPLE 1________________
        // Constructing a Healthy Meal
        IMealBuilder healthyMealBuilder = new HealthyMealBuilder();
        MealDirector director = new MealDirector();
        director.Construct(healthyMealBuilder);
        Meal healthyMeal = healthyMealBuilder.GetMeal();
        Console.WriteLine("Healthy Meal:");
        healthyMeal.Display();
        Console.WriteLine();
        // Constructing a Fast Food Meal
        IMealBuilder fastFoodMealBuilder = new FastFoodMealBuilder();
        director.Construct(fastFoodMealBuilder);
        Meal fastFoodMeal = fastFoodMealBuilder.GetMeal();
        Console.WriteLine("Fast Food Meal:");
        fastFoodMeal.Display();
        Console.WriteLine();
        // ____EAXMPLE 2________________
         // Constructing a Basic Computer
        IComputerBuilder basicComputerBuilder = new BasicComputerBuilder();
        ComputerDirector director2 = new ComputerDirector();
        director2.Construct(basicComputerBuilder);
        Computer basicComputer = basicComputerBuilder.GetComputer();
        Console.WriteLine("Basic Computer:");
        basicComputer.Display();
        Console.WriteLine();
        // Constructing a Gaming Computer
        IComputerBuilder gamingComputerBuilder = new GamingComputerBuilder();
        director2.Construct(gamingComputerBuilder);
        Computer gamingComputer = gamingComputerBuilder.GetComputer();
        Console.WriteLine("Gaming Computer:");
        gamingComputer.Display();
    }
}
