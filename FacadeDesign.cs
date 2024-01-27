using System;
// ______________EXAMPLE 1 ________________
// Subsystem components
class Amplifier
{
    public void TurnOn()
    {
        Console.WriteLine("Amplifier is on in Example 1");
    }

    public void TurnOff()
    {
        Console.WriteLine("Amplifier is off in Example 1");
    }
}

class DVDPlayer
{
    public void Play()
    {
        Console.WriteLine("DVD Player is playing in Example 1");
    }

    public void Stop()
    {
        Console.WriteLine("DVD Player stopped in Example 1");
    }
}

// Facade
class HomeTheaterFacade
{
    private Amplifier amplifier;
    private DVDPlayer dvdPlayer;


    public HomeTheaterFacade(Amplifier amplifier, DVDPlayer dvdPlayer)
    {
        this.amplifier = amplifier;
        this.dvdPlayer = dvdPlayer;
    }

    public void WatchMovie()
    {
        Console.WriteLine("Example1-Get ready to watch a movie...");
        amplifier.TurnOn();
        dvdPlayer.Play();
    }
    public void EndMovie()
    {
        Console.WriteLine("Example1-Shutting down the home theater...");
        amplifier.TurnOff();
        dvdPlayer.Stop();
    }
}
// _________________EXAMPLE 2 _____________

// Subsystem components
class Scanner
{
    public void Scan()
    {
        Console.WriteLine("Scanning source code in Example 2");
    }
}

class Parser
{
    public void Parse()
    {
        Console.WriteLine("Parsing source code in Example 2");
    }
}

// Facade
class CompilerFacade
{
    private Scanner scanner;
    private Parser parser;

    public CompilerFacade(Scanner scanner, Parser parser)
    {
        this.scanner = scanner;
        this.parser = parser;
    }

    public void Compile()
    {
        scanner.Scan();
        parser.Parse();
        Console.WriteLine("Compilation completed successfully in Example 2.");
    }
}

// Client code
class Program
{
    static void Main()
    {
        // _________________EXAMPLE 1 _____________
        Amplifier amplifier = new Amplifier();
        DVDPlayer dvdPlayer = new DVDPlayer();
        HomeTheaterFacade homeTheater = new HomeTheaterFacade(amplifier, dvdPlayer);
        homeTheater.WatchMovie();
        homeTheater.EndMovie();
        // _________________EXAMPLE 2 _____________
        Scanner scanner = new Scanner();
        Parser parser = new Parser();
        CompilerFacade compiler = new CompilerFacade(scanner, parser);
        compiler.Compile();

    }
}
