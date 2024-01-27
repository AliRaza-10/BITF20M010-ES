using System;
// _____________EXAMPLE 1__________
// Subject
interface IImage
{
    void Display();
}

// RealSubject
class HighResolutionImage : IImage
{
    private string filename;

    public HighResolutionImage(string filename)
    {
        this.filename = filename;
        LoadImage();
    }

    private void LoadImage()
    {
        Console.WriteLine($"Loading image: {filename} in Example 1");
        // Simulate resource-intensive image loading
    }

    public void Display()
    {
        Console.WriteLine($"Displaying image: {filename} in Example 1");
    }
}

// Proxy
class ImageProxy : IImage
{
    private HighResolutionImage realImage;
    private string filename;

    public ImageProxy(string filename)
    {
        this.filename = filename;
    }

    public void Display()
    {
        if (realImage == null)
        {
            realImage = new HighResolutionImage(filename);
        }
        realImage.Display();
    }
}
// _____________EXAMPLE 2__________

// Subject
interface ISensitiveOperation
{
    void PerformOperation();
}

// RealSubject
class SensitiveOperation : ISensitiveOperation
{
    public void PerformOperation()
    {
        Console.WriteLine("Performing sensitive operation in Example 2");
    }
}

// Proxy
class ProtectionProxy : ISensitiveOperation
{
    private SensitiveOperation realSubject;
    private string username;
    private string password;

    public ProtectionProxy(string username, string password)
    {
        this.username = username;
        this.password = password;
    }

    private bool Authenticate()
    {
        return username == "Raza" && password == "123";
    }

    public void PerformOperation()
    {
        if (Authenticate())
        {
            if (realSubject == null)
            {
                realSubject = new SensitiveOperation();
            }
            realSubject.PerformOperation();
        }
        else
        {
            Console.WriteLine("Authentication failed. Access denied.");
        }
    }
}

// Client code
class Program
{
    static void Main()
    {
        // _______________EXAMPLE 1 _______________
        IImage image = new ImageProxy("ALI.jpg");
        image.Display();
        // _________________EXAMPLE 2_______
        ISensitiveOperation operation = new ProtectionProxy("Ali", "wrongPassword");
        operation.PerformOperation();
        ISensitiveOperation unauthorizedOperation = new ProtectionProxy("Raza", "123");
        unauthorizedOperation.PerformOperation();
    }
}
