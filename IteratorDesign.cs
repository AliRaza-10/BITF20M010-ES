using System;
using System.Collections.Generic;

//______________EXAMPLE 1_____________
// Aggregate interface
interface IAggregate<T>
{
    IIterator<T> CreateIterator();
}

// Iterator interface
interface IIterator<T>
{
    bool HasNext();
    T Next();
}

// Concrete Aggregate
class CustomCollection<T> : IAggregate<T>
{
    private readonly List<T> _items = new List<T>();

    public void AddItem(T item)
    {
        _items.Add(item);
    }

    public IIterator<T> CreateIterator()
    {
        return new CustomIterator<T>(this);
    }

    public int Count()
    {
        return _items.Count;
    }

    public T GetItem(int index)
    {
        return _items[index];
    }
}

// Concrete Iterator
class CustomIterator<T> : IIterator<T>
{
    private readonly CustomCollection<T> _aggregate;
    private int _currentIndex;

    public CustomIterator(CustomCollection<T> aggregate)
    {
        _aggregate = aggregate;
        _currentIndex = 0;
    }

    public bool HasNext()
    {
        return _currentIndex < _aggregate.Count();
    }

    public T Next()
    {
        if (HasNext())
        {
            T currentItem = _aggregate.GetItem(_currentIndex);
            _currentIndex++;
            return currentItem;
        }
        else
        {
            throw new InvalidOperationException("End of collection reached");
        }
    }
}

// _______________EXAMPLE 2 ______

// Iterator interface
interface IIterator
{
    bool HasNext();
    object Next();
}

// Concrete Collection
class SimpleCollection
{
    private List<object> _items = new List<object>(); // Use List<object> instead of ArrayList

    public void AddItem(object item)
    {
        _items.Add(item);
    }

    public IIterator CreateIterator()
    {
        return new SimpleIterator(this);
    }

    // Concrete Iterator
    private class SimpleIterator : IIterator
    {
        private SimpleCollection _collection;
        private int _currentIndex = 0;

        public SimpleIterator(SimpleCollection collection)
        {
            _collection = collection;
        }

        public bool HasNext()
        {
            return _currentIndex < _collection.Count();
        }

        public object Next()
        {
            if (HasNext())
            {
                object currentItem = _collection.GetItem(_currentIndex);
                _currentIndex++;
                return currentItem;
            }
            else
            {
                throw new InvalidOperationException("End of collection reached");
            }
        }
    }

    public int Count()
    {
        return _items.Count;
    }

    public object GetItem(int index)
    {
        return _items[index];
    }
}

class Program
{
    static void Main()
    {
        //______________EXAMPLE 1_____________
        CustomCollection<int> numericCollection = new CustomCollection<int>();
        for (int i = 1; i <= 5; i++)
        {
            numericCollection.AddItem(i);
        }

        IIterator<int> numericIterator = numericCollection.CreateIterator();
        while (numericIterator.HasNext())
        {
            int number = numericIterator.Next();
            Console.WriteLine(number);
        }
        Console.WriteLine();
        // _______________EXAMPLE 2 ______
        SimpleCollection simpleCollection = new SimpleCollection();
        simpleCollection.AddItem("Item 1");
        simpleCollection.AddItem("Item 2");
        simpleCollection.AddItem("Item 3");
        IIterator iterator = simpleCollection.CreateIterator();
        while (iterator.HasNext())
        {
            object item = iterator.Next();
            Console.WriteLine(item);
        }
    }
}
