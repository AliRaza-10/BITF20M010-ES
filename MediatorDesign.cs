using System;
using System.Collections.Generic;
//__________________EXAMPLE 1_________
// Mediator interface
interface IChatMediator
{
    void SendMessage(string message, Participant participant);
    void AddParticipant(Participant participant);
}

// Concrete Mediator
class ChatMediator : IChatMediator
{
    private List<Participant> participants = new List<Participant>();

    public void AddParticipant(Participant participant)
    {
        participants.Add(participant);
    }

    public void SendMessage(string message, Participant sender)
    {
        foreach (var participant in participants)
        {
            if (participant != sender)
            {
                participant.ReceiveMessage(message);
            }
        }
    }
}

// Colleague interface
abstract class Participant
{
    protected IChatMediator mediator;
    public string Name { get; }

    public Participant(string name, IChatMediator mediator)
    {
        Name = name;
        this.mediator = mediator;
    }

    public abstract void Send(string message);
    public abstract void ReceiveMessage(string message);
}

// Concrete Colleague
class ConcreteParticipant : Participant
{
    public ConcreteParticipant(string name, IChatMediator mediator) : base(name, mediator) { }

    public override void Send(string message)
    {
        Console.WriteLine($"{Name} sends: {message}");
        mediator.SendMessage(message, this);
    }

    public override void ReceiveMessage(string message)
    {
        Console.WriteLine($"{Name} receives: {message}");
    }
}

//__________________EXAMPLE 2_________

// Mediator interface
interface IAirTrafficControl
{
    void RegisterFlight(Flight flight);
    void SendMessage(string message, Flight sender);
}

// Concrete Mediator
class AirTrafficControl : IAirTrafficControl
{
    private List<Flight> flights = new List<Flight>();

    public void RegisterFlight(Flight flight)
    {
        flights.Add(flight);
    }

    public void SendMessage(string message, Flight sender)
    {
        foreach (var flight in flights)
        {
            if (flight != sender)
            {
                flight.ReceiveMessage(message);
            }
        }
    }
}

// Colleague interface
abstract class Flight
{
    protected IAirTrafficControl airTrafficControl;
    public string FlightNumber { get; }

    public Flight(string flightNumber, IAirTrafficControl airTrafficControl)
    {
        FlightNumber = flightNumber;
        this.airTrafficControl = airTrafficControl;
    }

    public abstract void TakeOff();
    public abstract void Land();
    public abstract void ReceiveMessage(string message);
}

// Concrete Colleague
class Airplane : Flight
{
    public Airplane(string flightNumber, IAirTrafficControl airTrafficControl) : base(flightNumber, airTrafficControl) { }

    public override void TakeOff()
    {
        Console.WriteLine($"Flight {FlightNumber} is taking off.");
        airTrafficControl.SendMessage($"Flight {FlightNumber} is taking off.", this);
    }

    public override void Land()
    {
        Console.WriteLine($"Flight {FlightNumber} is landing.");
        airTrafficControl.SendMessage($"Flight {FlightNumber} is landing.", this);
    }

    public override void ReceiveMessage(string message)
    {
        Console.WriteLine($"Flight {FlightNumber} receives: {message}");
    }
}



class Program
{
    static void Main()
    {
        //__________________EXAMPLE 1_________
        IChatMediator chatMediator = new ChatMediator();
        Participant participant1 = new ConcreteParticipant("Ali", chatMediator);
        Participant participant2 = new ConcreteParticipant("Raza", chatMediator);
        Participant participant3 = new ConcreteParticipant("Malik", chatMediator);
        chatMediator.AddParticipant(participant1);
        chatMediator.AddParticipant(participant2);
        chatMediator.AddParticipant(participant3);
        participant1.Send("Hello, everyone!");
        participant2.Send("Hi, BITF20M010!");
        Console.WriteLine();
        //__________________EXAMPLE 2_________
        IAirTrafficControl airTrafficControl = new AirTrafficControl();
        Flight flight1 = new Airplane("A123", airTrafficControl);
        Flight flight2 = new Airplane("B456", airTrafficControl);
        airTrafficControl.RegisterFlight(flight1);
        airTrafficControl.RegisterFlight(flight2);
        flight1.TakeOff();
        flight2.Land();
    }
}
