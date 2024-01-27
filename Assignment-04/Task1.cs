using System;
using System.Collections.Generic;
using System.Linq;
public class EquationSolver
{
    public static string Solve(string equation)
    {
        try
        {
            if (IsValidEquation(equation))
            {
                double result = EvaluateExpression(equation);
                return result.ToString();
            }
            else
            {
                return "Invalid equation";
            }
        }
        catch (Exception ex)
        {
            return  ex.Message;
        }
    }

    private static bool IsValidEquation(string equation)
    {

        equation = equation.Replace(" ", "");
        // Check for invalid characters
        foreach (char c in equation)
        {
            if (!IsValidCharacter(c))
            {
                return false;
            }
        }

        // Check for invalid sequences like "++", "--", "+*", "/*", etc.
        for (int i = 1; i < equation.Length; i++)
        {
            char current = equation[i];
            char previous = equation[i - 1];
            if (IsInvalidSequence(previous, current))
            {
                return false;
            }
        }

        // Check for missing operands and operators
        if (equation.EndsWith("+") || equation.EndsWith("-") || equation.EndsWith("*") || equation.EndsWith("/") ||
            equation.EndsWith("(") || equation.Contains(")("))
        {
            return false;
        }

        // Check for unbalanced parentheses
        int openParentheses = equation.Count(c => c == '(');
        int closeParentheses = equation.Count(c => c == ')');
        if (openParentheses != closeParentheses)
        {
            return false;
        }

        return true;
    }
    private static bool IsValidCharacter(char c)
    {
        return Char.IsDigit(c) || c == '+' || c == '-' || c == '*' || c == '/' || c == '(' || c == ')';
    }
    private static bool IsInvalidSequence(char previous, char current)
    {
        return (previous == '+' || previous == '-' || previous == '*' || previous == '/') &&
               (current == '+' || current == '-' || current == '*' || current == '/');
    }
    private static double EvaluateExpression(string equation)
    {
        equation = equation.Replace(" ", "");
        return CalculateBODMAS(equation);
    }

    private static double CalculateBODMAS(string equation)
    {
        Stack<double> operands = new Stack<double>();
        Stack<char> operators = new Stack<char>();
        int index = 0;

        while (index < equation.Length)
        {
            char currentChar = equation[index];

            if (Char.IsDigit(currentChar) || currentChar == '.')
            {
                string operand = "";
                while (index < equation.Length && (Char.IsDigit(equation[index]) || equation[index] == '.'))
                {
                    operand += equation[index];
                    index++;
                }
                operands.Push(double.Parse(operand));
            }
            else if (currentChar == '(')
            {
                operators.Push(currentChar);
                index++;
            }
            else if (currentChar == ')')
            {
                while (operators.Count > 0 && operators.Peek() != '(')
                {
                    PerformOperation(operands, operators);
                }
                operators.Pop(); // Pop the '('
                index++;
            }
            else if (IsOperator(currentChar))
            {
                while (operators.Count > 0 && Priority(operators.Peek()) >= Priority(currentChar))
                {
                    PerformOperation(operands, operators);
                }
                operators.Push(currentChar);
                index++;
            }
            else
            {
                throw new Exception("Invalid character in the equation.");
            }
        }

        while (operators.Count > 0)
        {
            PerformOperation(operands, operators);
        }

        if (operands.Count == 1 && operators.Count == 0)
        {
            return operands.Pop();
        }
        else
        {
            throw new Exception("Invalid equation.");
        }
    }

    private static bool IsOperator(char c)
    {
        return c == '+' || c == '-' || c == '*' || c == '/';
    }

    private static int Priority(char op)
    {
        if (op == '*' || op == '/')
        {
            return 2;
        }
        if (op == '+' || op == '-')
        {
            return 1;
        }
        return 0;
    }

    private static void PerformOperation(Stack<double> operands, Stack<char> operators)
    {
        char op = operators.Pop();
        double operand2 = operands.Pop();
        double operand1 = operands.Pop();
        double result = ApplyOperator(operand1, operand2, op);
        operands.Push(result);
    }

    private static double ApplyOperator(double operand1, double operand2, char op)
    {
        switch (op)
        {
            case '+':
                return operand1 + operand2;
            case '-':
                return operand1 - operand2;
            case '*':
                return operand1 * operand2;
            case '/':
                if (operand2 == 0)
                {
                    throw new DivideByZeroException("Division by zero is not allowed.");
                }
                return operand1 / operand2;
            default:
                throw new Exception("Invalid operator.");
        }
    }
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter an equation : ");
        string? equation = Console.ReadLine();
        string result = Solve(equation!);
        Console.WriteLine($"Result: {result}");
    }
}
