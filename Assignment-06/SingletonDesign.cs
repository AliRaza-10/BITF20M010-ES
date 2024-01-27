using System;
// ___________EXAMPLE 1_____________    
// Thread Safety Singleton using Double-Check Locking
public sealed class SingletonDesign
{
    private SingletonDesign() { }

    private static SingletonDesign instance;
    private static object locker = new object();

    public static SingletonDesign GetInstance()
    {
        if (instance == null)
        {
            lock (locker)
            {
                if (instance == null)
                {
                    Console.WriteLine("Instance Created");
                    instance = new SingletonDesign();
                }
            }
        }
        return instance;
    }

    public void DisplayMessage()
    {
        Console.WriteLine("Singleton instance is displaying a message.");
    }
}
// ___________EXAMPLE 2_____________
// Singleton using Lazy Initialization
public sealed class LazySingleton
{
    private LazySingleton()
    {
        Console.WriteLine("LazySingleton instance created.");
    }

    private static readonly Lazy<LazySingleton> lazyInstance = new Lazy<LazySingleton>(() => new LazySingleton());

    public static LazySingleton GetInstance()
    {
        return lazyInstance.Value;
    }

    public void DisplayMessage()
    {
        Console.WriteLine("LazySingleton instance is displaying a message.");
    }
}

public class Program
{
    public static void Main()
    {
        // Example 1 of Thread Safety Singleton
        SingletonDesign s = SingletonDesign.GetInstance();
        s.DisplayMessage();

        SingletonDesign s2 = SingletonDesign.GetInstance();
        s2.DisplayMessage();

        // Example 2 of Simple Singleton using Lazy Initialization
        LazySingleton lazySingleton1 = LazySingleton.GetInstance();
        lazySingleton1.DisplayMessage();

        LazySingleton lazySingleton2 = LazySingleton.GetInstance();
        lazySingleton2.DisplayMessage();
    }
}

