using System;
//_____EXAMPLE 1_____
// Abstract Product: Engine
public interface IEngine
{
    void Start();
}

// Concrete Products for Elantra
public class ElantraEngine : IEngine
{
    public void Start()
    {
        Console.WriteLine("Elantra engine started.");
    }
}

// Concrete Products for Civic
public class CivicEngine : IEngine
{
    public void Start()
    {
        Console.WriteLine("Civic engine started.");
    }
}

// Abstract Product: IFrame
public interface IFrame
{
    void Assemble();
}

// Concrete Products for Elantra
public class ElantraFrame : IFrame
{
    public void Assemble()
    {
        Console.WriteLine("Assembling Elantra IFrame.");
    }
}

// Concrete Products for Civic
public class CivicFrame : IFrame
{
    public void Assemble()
    {
        Console.WriteLine("Assembling Civic IFrame.");
    }
}

// Abstract Factory
public interface ICarFactory
{
    IEngine CreateEngine();
    IFrame CreateFrame();
}

// Concrete Factory for Elantra
public class ElantraFactory : ICarFactory
{
    public IEngine CreateEngine()
    {
        return new ElantraEngine();
    }

    public IFrame CreateFrame()
    {
        return new ElantraFrame();
    }
}

// Concrete Factory for Civic
public class CivicFactory : ICarFactory
{
    public IEngine CreateEngine()
    {
        return new CivicEngine();
    }

    public IFrame CreateFrame()
    {
        return new CivicFrame();
    }
}

// Client Code
public class CarClient
{
    private ICarFactory carFactory;

    public CarClient(ICarFactory factory)
    {
        this.carFactory = factory;
    }

    public void AssembleCar()
    {
        IEngine engine = carFactory.CreateEngine();
        IFrame frame = carFactory.CreateFrame();
        engine.Start();
        frame.Assemble();
        Console.WriteLine("Car assembled!");
    }
}

//_____EXAMPLE 2_____
// Abstract Product: Dough
public interface IDough
{
    void PrepareDough();
}

// Concrete Products for Thin Crust Dough
public class ThinCrustDough : IDough
{
    public void PrepareDough()
    {
        Console.WriteLine("Preparing thin crust dough.");
    }
}

// Concrete Products for Thick Crust Dough
public class ThickCrustDough : IDough
{
    public void PrepareDough()
    {
        Console.WriteLine("Preparing thick crust dough.");
    }
}

// Abstract Product: Sauce
public interface ISauce
{
    void AddSauce();
}

// Concrete Products for Marinara Sauce
public class MarinaraSauce : ISauce
{
    public void AddSauce()
    {
        Console.WriteLine("Adding marinara sauce.");
    }
}

// Concrete Products for Alfredo Sauce
public class AlfredoSauce : ISauce
{
    public void AddSauce()
    {
        Console.WriteLine("Adding Alfredo sauce.");
    }
}

// Abstract Product: Topping
public interface ITopping
{
    void AddTopping();
}

// Concrete Products for Cheese Topping
public class CheeseTopping : ITopping
{
    public void AddTopping()
    {
        Console.WriteLine("Adding cheese topping.");
    }
}

// Concrete Products for Pepperoni Topping
public class PepperoniTopping : ITopping
{
    public void AddTopping()
    {
        Console.WriteLine("Adding pepperoni topping.");
    }
}

// Abstract Factory
public interface IPizzaFactory
{
    IDough CreateDough();
    ISauce CreateSauce();
    ITopping CreateTopping();
}

// Concrete Factory for Margherita Pizza
public class MargheritaPizzaFactory : IPizzaFactory
{
    public IDough CreateDough()
    {
        return new ThinCrustDough();
    }

    public ISauce CreateSauce()
    {
        return new MarinaraSauce();
    }

    public ITopping CreateTopping()
    {
        return new CheeseTopping();
    }
}

// Concrete Factory for Pepperoni Pizza
public class PepperoniPizzaFactory : IPizzaFactory
{
    public IDough CreateDough()
    {
        return new ThickCrustDough();
    }

    public ISauce CreateSauce()
    {
        return new MarinaraSauce();
    }

    public ITopping CreateTopping()
    {
        return new PepperoniTopping();
    }
}

// Client Code
public class PizzaClient
{
    private IPizzaFactory pizzaFactory;

    public PizzaClient(IPizzaFactory factory)
    {
        this.pizzaFactory = factory;
    }

    public void PreparePizza()
    {
        IDough dough = pizzaFactory.CreateDough();
        ISauce sauce = pizzaFactory.CreateSauce();
        ITopping topping = pizzaFactory.CreateTopping();

        dough.PrepareDough();
        sauce.AddSauce();
        topping.AddTopping();

        Console.WriteLine("Pizza prepared!");
    }
}

class Program
{
    static void Main()
    {
        //_____EXAMPLE 1 _________
        // Using Elantra Factory
        ICarFactory elantraFactory = new ElantraFactory();
        CarClient elantraClient = new CarClient(elantraFactory);
        elantraClient.AssembleCar();
        Console.WriteLine();
        // Using Civic Factory
        ICarFactory civicFactory = new CivicFactory();
        CarClient civicClient = new CarClient(civicFactory);
        civicClient.AssembleCar();
        Console.WriteLine();
        //_____EXAMPLE 2 _________
        // Making a Margherita Pizza
        IPizzaFactory margheritaFactory = new MargheritaPizzaFactory();
        PizzaClient margheritaClient = new PizzaClient(margheritaFactory);
        margheritaClient.PreparePizza();
        Console.WriteLine();
        // Making a Pepperoni Pizza
        IPizzaFactory pepperoniFactory = new PepperoniPizzaFactory();
        PizzaClient pepperoniClient = new PizzaClient(pepperoniFactory);
        pepperoniClient.PreparePizza();
    }
}
