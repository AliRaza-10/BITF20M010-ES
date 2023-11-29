using System;
using System.Collections.Generic;
using System.Text; // Add this using directive for StringBuilder

// ________EXAMPLE 1 ____________
// Originator
class Originator
{
    private string state;

    public string State
    {
        get { return state; }
        set
        {
            Console.WriteLine($"Setting state to: {value}");
            state = value;
        }
    }

    public Memento CreateMemento()
    {
        return new Memento(state);
    }

    public void RestoreMemento(Memento memento)
    {
        State = memento.State;
    }
}

// Memento
class Memento
{
    public string State { get; }

    public Memento(string state)
    {
        State = state;
    }
}

// Caretaker
class Caretaker
{
    public Memento Memento { get; set; }
}

// ________EXAMPLE 2 ____________

// Originator
class TextEditor
{
    private StringBuilder text = new StringBuilder();
    private Stack<Memento> history = new Stack<Memento>();

    public string Text
    {
        get { return text.ToString(); }
        set
        {
            Console.WriteLine($"Setting text to: {value}");
            text.Clear();
            text.Append(value);
            Save();
        }
    }

    public void AddText(string additionalText)
    {
        Console.WriteLine($"Adding text: {additionalText}");
        text.Append(additionalText);
        Save();
    }

    public void Undo()
    {
        if (history.Count > 0)
        {
            Memento memento = history.Pop();
            text.Clear();
            text.Append(memento.State);
        }
    }

    private void Save()
    {
        history.Push(new Memento(text.ToString()));
    }
}

class TextMemento // Rename to avoid conflict with Memento class in Example 1
{
    public string State { get; }

    public TextMemento(string state)
    {
        State = state;
    }
}

class Program
{
    static void Main()
    {
        // ________EXAMPLE 1 ____________
        Originator originator = new Originator();
        Caretaker caretaker = new Caretaker();
        originator.State = "State1";
        caretaker.Memento = originator.CreateMemento();
        originator.State = "State2";
        originator.RestoreMemento(caretaker.Memento);
        Console.WriteLine($"Current state: {originator.State}");
        Console.WriteLine();
        // ________EXAMPLE 2 ____________
        TextEditor textEditor = new TextEditor();
        textEditor.Text = "Hello, ";
        textEditor.AddText("ali!");
        textEditor.Undo();
        Console.WriteLine($"Current text: {textEditor.Text}");
    }
}
