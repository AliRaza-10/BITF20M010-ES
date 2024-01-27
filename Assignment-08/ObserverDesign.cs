using System;
using System.Collections.Generic;
// ___________________EXAMPLE 1 ____________
// Subject interface
interface IStock
{
    string Symbol { get; }
    double Price { get; set; }

    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}

// Concrete Subject
class Stock : IStock
{
    private readonly List<IObserver> _observers = new List<IObserver>();

    public string Symbol { get; }
    private double _price;

    public double Price
    {
        get { return _price; }
        set
        {
            if (_price != value)
            {
                _price = value;
                Notify(); // Notify observers about the price change
            }
        }
    }

    public Stock(string symbol, double price)
    {
        Symbol = symbol;
        _price = price;
    }

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Update(this);
        }
    }
}

// Observer interface
interface IObserver
{
    void Update(IStock stock);
}

// Concrete Observer
class StockObserver : IObserver
{
    private string _name;

    public StockObserver(string name)
    {
        _name = name;
    }

    public void Update(IStock stock)
    {
        Console.WriteLine($"Notified {_name} of {stock.Symbol}'s price change to {stock.Price:C}");
    }
}

// ___________________EXAMPLE 2 ____________

// Subject interface
interface INewsAgency
{
    void RegisterObserver(INewsChannel observer);
    void RemoveObserver(INewsChannel observer);
    void NotifyObservers(string news);
}

// Concrete Subject
class NewsAgency : INewsAgency
{
    private List<INewsChannel> _newsChannels = new List<INewsChannel>();

    public void RegisterObserver(INewsChannel observer)
    {
        _newsChannels.Add(observer);
    }

    public void RemoveObserver(INewsChannel observer)
    {
        _newsChannels.Remove(observer);
    }

    public void NotifyObservers(string news)
    {
        foreach (var observer in _newsChannels)
        {
            observer.Update(news);
        }
    }

    public void PublishNews(string news)
    {
        Console.WriteLine($"News Agency publishes: {news}");
        NotifyObservers(news);
    }
}

// Observer interface
interface INewsChannel
{
    void Update(string news);
}

// Concrete Observer
class NewsChannel : INewsChannel
{
    private string _channelName;

    public NewsChannel(string channelName)
    {
        _channelName = channelName;
    }

    public void Update(string news)
    {
        Console.WriteLine($"{_channelName} receives news: {news}");
    }
}



class Program
{
    static void Main()
    {
        // ___________________EXAMPLE 1 ____________
        Stock stock = new Stock("ABC", 100.00);
        IObserver investor1 = new StockObserver("Investor 1");
        IObserver investor2 = new StockObserver("Investor 2");
        stock.Attach(investor1);
        stock.Attach(investor2);
        stock.Price = 101.50;
        stock.Price = 98.75;
        Console.WriteLine();
         // ___________________EXAMPLE 2 ____________
          NewsAgency newsAgency = new NewsAgency();
        INewsChannel cnn = new NewsChannel("GEO");
        INewsChannel bbc = new NewsChannel("ARY");
        INewsChannel foxNews = new NewsChannel("BOL News");
        newsAgency.RegisterObserver(cnn);
        newsAgency.RegisterObserver(bbc);
        newsAgency.RegisterObserver(foxNews);
        newsAgency.PublishNews("Breaking: New discovery in space exploration!");
    }
}
