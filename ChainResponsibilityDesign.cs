using System;
// _______________EXAMPLE 1 __________
// Handler interface
interface IApprover
{
    void ProcessRequest(Purchase purchase);
}

// Concrete Handler
class Manager : IApprover
{
    private readonly decimal _approvalLimit;

    public Manager(decimal approvalLimit)
    {
        _approvalLimit = approvalLimit;
    }

    public void ProcessRequest(Purchase purchase)
    {
        if (purchase.Amount <= _approvalLimit)
        {
            Console.WriteLine($"Manager approves purchase request #{purchase.RequestNumber}");
        }
        else
        {
            Console.WriteLine($"Manager cannot approve request #{purchase.RequestNumber}. Passing to the next approver.");
        }
    }
}

// Concrete Handler
class Director : IApprover
{
    private readonly decimal _approvalLimit;

    public Director(decimal approvalLimit)
    {
        _approvalLimit = approvalLimit;
    }

    public void ProcessRequest(Purchase purchase)
    {
        if (purchase.Amount <= _approvalLimit)
        {
            Console.WriteLine($"Director approves purchase request #{purchase.RequestNumber}");
        }
        else
        {
            Console.WriteLine($"Director cannot approve request #{purchase.RequestNumber}. Passing to the next approver.");
        }
    }
}

// Concrete Handler
class VicePresident : IApprover
{
    public void ProcessRequest(Purchase purchase)
    {
        Console.WriteLine($"Vice President approves purchase request #{purchase.RequestNumber}");
    }
}

// Request class
class Purchase
{
    public int RequestNumber { get; }
    public string Purpose { get; }
    public decimal Amount { get; }

    public Purchase(int requestNumber, string purpose, decimal amount)
    {
        RequestNumber = requestNumber;
        Purpose = purpose;
        Amount = amount;
    }
}

// _______________EXAMPLE 2 __________

// Handler interface
abstract class Logger
{
    protected Logger _nextLogger;

    public void SetNextLogger(Logger nextLogger)
    {
        _nextLogger = nextLogger;
    }

    public void LogMessage(LogLevel level, string message)
    {
        if (level <= LogLevel)
        {
            WriteMessage(message);
        }

        // Pass the request to the next logger in the chain
        _nextLogger?.LogMessage(level, message);
    }

    protected abstract void WriteMessage(string message);
    protected abstract LogLevel LogLevel { get; }
}

// Concrete Handlers
class ConsoleLogger : Logger
{
    protected override void WriteMessage(string message)
    {
        Console.WriteLine($"Console Logger: {message}");
    }

    protected override LogLevel LogLevel => LogLevel.Info;
}

class FileLogger : Logger
{
    protected override void WriteMessage(string message)
    {
        Console.WriteLine($"File Logger: {message}");
    }

    protected override LogLevel LogLevel => LogLevel.Warning;
}

class EmailLogger : Logger
{
    protected override void WriteMessage(string message)
    {
        Console.WriteLine($"Email Logger: {message}");
    }

    protected override LogLevel LogLevel => LogLevel.Error;
}

// Log level enumeration
enum LogLevel
{
    Info,
    Warning,
    Error
}



class Program
{
    static void Main()
    {
        /// _______________EXAMPLE 1 __________
        IApprover manager = new Manager(approvalLimit: 1000);
        IApprover director = new Director(approvalLimit: 5000);
        IApprover vicePresident = new VicePresident();

        manager.ProcessRequest(new Purchase(1, "Office supplies", 800));
        manager.ProcessRequest(new Purchase(2, "Conference room furniture", 2500));
        manager.ProcessRequest(new Purchase(3, "New servers", 10000));
        Console.WriteLine();
        // _______________EXAMPLE 2 __________
          // Setup the chain of responsibility
        Logger consoleLogger = new ConsoleLogger();
        Logger fileLogger = new FileLogger();
        Logger emailLogger = new EmailLogger();
        consoleLogger.SetNextLogger(fileLogger);
        fileLogger.SetNextLogger(emailLogger);
        consoleLogger.LogMessage(LogLevel.Info, "This is an information message.");
        consoleLogger.LogMessage(LogLevel.Warning, "This is a warning message.");
        consoleLogger.LogMessage(LogLevel.Error, "This is an error message.");
    }
}
