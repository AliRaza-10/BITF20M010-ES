using System;
using System.Collections.Generic;
// _______________EXAMPLE 1 _______
// Flyweight
interface ITextFormat
{
    void Apply(string text);
}

// ConcreteFlyweight
class TextFormat : ITextFormat
{
    private ConsoleColor color;

    public TextFormat(ConsoleColor color)
    {
        this.color = color;
    }

    public void Apply(string text)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ResetColor();
    }
}

// FlyweightFactory
class TextFormatFactory
{
    private Dictionary<ConsoleColor, ITextFormat> textFormats = new Dictionary<ConsoleColor, ITextFormat>();

    public ITextFormat GetTextFormat(ConsoleColor color)
    {
        if (!textFormats.ContainsKey(color))
        {
            textFormats[color] = new TextFormat(color);
        }
        return textFormats[color];
    }
}
// ___________________EXAMPLE 2______________ 
// Flyweight
interface ICharacter
{
    void Display(Font font);
}

// ConcreteFlyweight
class Character : ICharacter
{
    private char symbol;

    public Character(char symbol)
    {
        this.symbol = symbol;
    }

    public void Display(Font font)
    {
        Console.WriteLine($"Displaying '{symbol}' with font {font.Name} and size {font.Size} in example 2");
    }
}

// FlyweightFactory
class CharacterFactory
{
    private Dictionary<char, ICharacter> characters = new Dictionary<char, ICharacter>();

    public ICharacter GetCharacter(char symbol)
    {
        if (!characters.ContainsKey(symbol))
        {
            characters[symbol] = new Character(symbol);
        }
        return characters[symbol];
    }
}

// Unshared ConcreteFlyweight
class Font
{
    public string Name { get; }
    public int Size { get; }

    public Font(string name, int size)
    {
        Name = name;
        Size = size;
    }
}

// Client code
class Program
{
    static void Main()
    {
        // ___________________EXAMPLE 1______________
        TextFormatFactory formatFactory = new TextFormatFactory();
        ITextFormat redFormat = formatFactory.GetTextFormat(ConsoleColor.Red);
        ITextFormat greenFormat = formatFactory.GetTextFormat(ConsoleColor.Green);
        redFormat.Apply("This is red text in example 1.");
        greenFormat.Apply("This is green text in example 1.");
        // ___________________EXAMPLE  2________________
        CharacterFactory characterFactory = new CharacterFactory();
        Font font = new Font("Arial", 12);
        ICharacter charA = characterFactory.GetCharacter('A');
        ICharacter charB = characterFactory.GetCharacter('B');
        charA.Display(font);
        charB.Display(font);
    }
}
