using System;
// ______________EXAMPLE 1 __________
// Strategy interface
interface IPaymentStrategy
{
    void Pay(int amount);
}

// Concrete Strategies
class CreditCardPayment : IPaymentStrategy
{
    private string _creditCardNumber;

    public CreditCardPayment(string creditCardNumber)
    {
        _creditCardNumber = creditCardNumber;
    }

    public void Pay(int amount)
    {
        Console.WriteLine($"Paid {amount} using credit card ending in {_creditCardNumber.Substring(_creditCardNumber.Length - 4)}");
    }
}

class PayPalPayment : IPaymentStrategy
{
    private string _email;

    public PayPalPayment(string email)
    {
        _email = email;
    }

    public void Pay(int amount)
    {
        Console.WriteLine($"Paid {amount} using PayPal account {_email}");
    }
}

// Context
class ShoppingCart
{
    private IPaymentStrategy _paymentStrategy;

    public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
    }

    public void Checkout(int amount)
    {
        _paymentStrategy.Pay(amount);
    }
}
// ______________EXAMPLE 2 __________

// Strategy interface
interface IDrawingStrategy
{
    void Draw(string shape);
}

// Concrete Strategies
class PencilDrawing : IDrawingStrategy
{
    public void Draw(string shape)
    {
        Console.WriteLine($"Drawing {shape} with a pencil");
    }
}

class PenDrawing : IDrawingStrategy
{
    public void Draw(string shape)
    {
        Console.WriteLine($"Drawing {shape} with a pen");
    }
}

class BrushDrawing : IDrawingStrategy
{
    public void Draw(string shape)
    {
        Console.WriteLine($"Drawing {shape} with a brush");
    }
}

// Context
class DrawingApp
{
    private IDrawingStrategy _drawingStrategy;

    public void SetDrawingStrategy(IDrawingStrategy drawingStrategy)
    {
        _drawingStrategy = drawingStrategy;
    }

    public void DrawShape(string shape)
    {
        _drawingStrategy.Draw(shape);
    }
}

class Program
{
    static void Main()
    {
        // ______________EXAMPLE 1 __________
        ShoppingCart cart = new ShoppingCart();
        cart.SetPaymentStrategy(new CreditCardPayment("1234567890123456"));
        cart.Checkout(100);
        cart.SetPaymentStrategy(new PayPalPayment("ali@example.com"));
        cart.Checkout(50);
        Console.WriteLine();
        // ______________EXAMPLE 2 __________
        DrawingApp drawingApp = new DrawingApp();
        drawingApp.SetDrawingStrategy(new PencilDrawing());
        drawingApp.DrawShape("Circle");
        drawingApp.SetDrawingStrategy(new PenDrawing());
        drawingApp.DrawShape("Rectangle");
        drawingApp.SetDrawingStrategy(new BrushDrawing());
        drawingApp.DrawShape("Triangle");

    }
}
