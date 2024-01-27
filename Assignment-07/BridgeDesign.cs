using System;
// _______________EXAMPLE 1 __________________  
// Implementor
interface IMessageSender
{
    void SendMessage(string message);
}

// Concrete Implementor 1
class EmailSender : IMessageSender
{
    public void SendMessage(string message)
    {
        Console.WriteLine($"Sending email: {message} in Example 1");
    }
}

// Concrete Implementor 2
class SMSSender : IMessageSender
{
    public void SendMessage(string message)
    {
        Console.WriteLine($"Sending SMS: {message} in Example 1");
    }
}

// Abstraction
abstract class Message
{
    protected IMessageSender messageSender;

    protected Message(IMessageSender messageSender)
    {
        this.messageSender = messageSender;
    }

    public abstract void Send(string body);
}

// Refined Abstraction 
class ShortMessage : Message
{
    public ShortMessage(IMessageSender messageSender) : base(messageSender)
    {
    }

    public override void Send(string body)
    {
        Console.WriteLine("Sending a short message in example 1");
        messageSender.SendMessage(body);
    }
}

//___________________EXAMPLE 2 ______________________

// Implementor
interface IDrawingAPI
{
    void DrawCircle(int radius, int x, int y);
}

// Concrete Implementor 1
class DrawingAPI1 : IDrawingAPI
{
    public void DrawCircle(int radius, int x, int y)
    {
        Console.WriteLine($"API1: Drawing Circle at ({x}, {y}) with radius {radius} in example 2");
    }
}

// Concrete Implementor 2
class DrawingAPI2 : IDrawingAPI
{
    public void DrawCircle(int radius, int x, int y)
    {
        Console.WriteLine($"API2: Drawing Circle at ({x}, {y}) with radius {radius} in example 2");
    }
}

// Abstraction
abstract class Shape
{
    protected IDrawingAPI drawingAPI;

    protected Shape(IDrawingAPI drawingAPI)
    {
        this.drawingAPI = drawingAPI;
    }

    public abstract void Draw();
}

// Refined Abstraction 
class Circle : Shape
{
    private int x, y, radius;

    public Circle(int x, int y, int radius, IDrawingAPI drawingAPI) : base(drawingAPI)
    {
        this.x = x;
        this.y = y;
        this.radius = radius;
    }

    public override void Draw()
    {
        drawingAPI.DrawCircle(radius, x, y);
    }
}

// Client code
class Program
{
    static void Main()
    {
         // __________EXAMPLE 1__________
        IMessageSender emailSender = new EmailSender();
        IMessageSender smsSender = new SMSSender();
        Message shortMessageWithEmail = new ShortMessage(emailSender);
        Message shortMessageWithSMS = new ShortMessage(smsSender);
        shortMessageWithEmail.Send("Hello, Ali ! how are you?");
        shortMessageWithSMS.Send("Hi there!");
        // __________EXAMPLE 2__________
        IDrawingAPI api1 = new DrawingAPI1();
        IDrawingAPI api2 = new DrawingAPI2();
        Shape circle1 = new Circle(1, 2, 3, api1);
        Shape circle2 = new Circle(4, 5, 6, api2);
        circle1.Draw();
        circle2.Draw();
    }
}
