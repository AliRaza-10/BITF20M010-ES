using System;
// _______EXAMPLE 1__________
// Product interface 
public interface IProduct
{
    void Display();
}

// ConcreteProductA class
public class ConcreteProductA : IProduct
{
    public void Display()
    {
        Console.WriteLine("ConcreteProductA is displayed.");
    }
}

// ConcreteProductB class
public class ConcreteProductB : IProduct
{
    public void Display()
    {
        Console.WriteLine("ConcreteProductB is displayed.");
    }
}

// Factory interface
public interface IFactory
{
    IProduct CreateProduct();
}

// ConcreteFactoryA class
public class ConcreteFactoryA : IFactory
{
    public IProduct CreateProduct()
    {
        return new ConcreteProductA();
    }
}

// ConcreteFactoryB class
public class ConcreteFactoryB : IFactory
{
    public IProduct CreateProduct()
    {
        return new ConcreteProductB();
    }
}
//_________EXAMPLE 2__________
// Document interface 
public interface IDocument
{
    void Open();
    void Close();
}

// PDFDocument class
public class PDFDocument : IDocument
{
    public void Open()
    {
        Console.WriteLine("Opening PDF document.");
    }

    public void Close()
    {
        Console.WriteLine("Closing PDF document.");
    }
}

// WordDocument class
public class WordDocument : IDocument
{
    public void Open()
    {
        Console.WriteLine("Opening Word document.");
    }

    public void Close()
    {
        Console.WriteLine("Closing Word document.");
    }
}

// TextDocument class
public class TextDocument : IDocument
{
    public void Open()
    {
        Console.WriteLine("Opening Text document.");
    }

    public void Close()
    {
        Console.WriteLine("Closing Text document.");
    }
}

// DocumentFactory interface
public interface IDocumentFactory
{
    IDocument CreateDocument();
}

// PDFDocumentFactory class
public class PDFDocumentFactory : IDocumentFactory
{
    public IDocument CreateDocument()
    {
        return new PDFDocument();
    }
}

// WordDocumentFactory class
public class WordDocumentFactory : IDocumentFactory
{
    public IDocument CreateDocument()
    {
        return new WordDocument();
    }
}

// TextDocumentFactory class
public class TextDocumentFactory : IDocumentFactory
{
    public IDocument CreateDocument()
    {
        return new TextDocument();
    }
}

// Client class using the factory
public class Client
{
    private IFactory factory;

    public Client(IFactory factory)
    {
        this.factory = factory;
    }

    public void DisplayProduct()
    {
        IProduct product = factory.CreateProduct();
        product.Display();
    }
}

// DocumentClient class using the document factory
public class DocumentClient
{
    private IDocumentFactory documentFactory;

    public DocumentClient(IDocumentFactory documentFactory)
    {
        this.documentFactory = documentFactory;
    }

    public void ProcessDocument()
    {
        IDocument document = documentFactory.CreateDocument();
        document.Open();
        document.Close();
    }
}

class Program
{
    static void Main()
    {
        // _________EXAMPLE 1__________
        // Using ConcreteFactoryA to create ConcreteProductA
        IFactory factoryA = new ConcreteFactoryA();
        Client clientA = new Client(factoryA);
        clientA.DisplayProduct();

        // Using ConcreteFactoryB to create ConcreteProductB
        IFactory factoryB = new ConcreteFactoryB();
        Client clientB = new Client(factoryB);
        clientB.DisplayProduct();
        // _______EXAMPLE 2 ___________
        // Using PDFDocumentFactory to create PDFDocument
        IDocumentFactory pdfFactory = new PDFDocumentFactory();
        DocumentClient pdfClient = new DocumentClient(pdfFactory);
        pdfClient.ProcessDocument();

        // Using WordDocumentFactory to create WordDocument
        IDocumentFactory wordFactory = new WordDocumentFactory();
        DocumentClient wordClient = new DocumentClient(wordFactory);
        wordClient.ProcessDocument();

        // Using TextDocumentFactory to create TextDocument
        IDocumentFactory textFactory = new TextDocumentFactory();
        DocumentClient textClient = new DocumentClient(textFactory);
        textClient.ProcessDocument();
    }
}
