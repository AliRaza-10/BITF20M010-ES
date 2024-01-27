using System;
using System.Text.RegularExpressions;

// __________EXAMPLE 1 ___________
// Context
class Context
{
    public int Variable { get; set; }
}

// Expression interface
interface IExpression
{
    int Interpret(Context context);
}

// Terminal Expression
class NumberExpression : IExpression
{
    private readonly int _number;

    public NumberExpression(int number)
    {
        _number = number;
    }

    public int Interpret(Context context) => _number;
}

// Non-terminal Expression
class AddExpression : IExpression
{
    private readonly IExpression _left;
    private readonly IExpression _right;

    public AddExpression(IExpression left, IExpression right)
    {
        _left = left;
        _right = right;
    }

    public int Interpret(Context context) => _left.Interpret(context) + _right.Interpret(context);
}

// __________EXAMPLE 2 ___________

// Context
class ContextRegex
{
    private readonly string _input;

    public ContextRegex(string input)
    {
        _input = input;
    }

    public bool Match(string pattern) => Regex.IsMatch(_input, pattern);
}

// Expression interface
interface IRegexExpression
{
    bool Interpret(ContextRegex context);
}

// Terminal Expression
class LiteralExpression : IRegexExpression
{
    private readonly string _literal;

    public LiteralExpression(string literal) => _literal = literal;

    public bool Interpret(ContextRegex context) => context.Match(_literal);
}

// Non-terminal Expression
class OrExpression : IRegexExpression
{
    private readonly IRegexExpression _left;
    private readonly IRegexExpression _right;

    public OrExpression(IRegexExpression left, IRegexExpression right)
    {
        _left = left;
        _right = right;
    }
    public bool Interpret(ContextRegex context) => _left.Interpret(context) || _right.Interpret(context);
}

class Program
{
    static void Main()
    {
        // __________EXAMPLE 1 ___________
        Context context1 = new Context { Variable = 3 };
        IExpression expression1 = new AddExpression(
            new NumberExpression(2),
            new NumberExpression(context1.Variable)
        );
        int result1 = expression1.Interpret(context1);
        Console.WriteLine("Result Example 1: " + result1);
        Console.WriteLine();
        // __________EXAMPLE 2 ___________
        ContextRegex context2 = new ContextRegex("abef");

        IRegexExpression expression2 = new OrExpression(
            new LiteralExpression("ab"),
            new LiteralExpression("cd")
        );
        bool result2 = expression2.Interpret(context2);
        Console.WriteLine("Result Example 2: " + result2);
    }
}
