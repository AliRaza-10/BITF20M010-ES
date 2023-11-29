using System;
// ________________EXAMPLE 1_____________
// Command interface
interface ITextCommand
{
    void Execute();
}

// Concrete Commands
class AddTextCommand : ITextCommand
{
    private TextEditor _editor;
    private string _text;

    public AddTextCommand(TextEditor editor, string text)
    {
        _editor = editor;
        _text = text;
    }

    public void Execute()
    {
        _editor.AddText(_text);
    }
}

class DeleteTextCommand : ITextCommand
{
    private TextEditor _editor;

    public DeleteTextCommand(TextEditor editor)
    {
        _editor = editor;
    }

    public void Execute()
    {
        _editor.DeleteText();
    }
}

// Receiver
class TextEditor
{
    private string _content = "";

    public void AddText(string text)
    {
        _content += text;
        Console.WriteLine("Text added: " + text);
        Console.WriteLine("Current content: " + _content);
    }

    public void DeleteText()
    {
        if (_content.Length > 0)
        {
            _content = _content.Substring(0, _content.Length - 1);
            Console.WriteLine("Last character deleted.");
            Console.WriteLine("Current content: " + _content);
        }
        else
        {
            Console.WriteLine("No text to delete.");
        }
    }
}

// Invoker
class User
{
    private ITextCommand _command;

    public void SetCommand(ITextCommand command)
    {
        _command = command;
    }

    public void ExecuteCommand()
    {
        _command.Execute();
    }
}
//________________EXAMPLE 2_____________

// Command interface
interface ICommand
{
    void Execute();
}

// Concrete Commands
class LightOnCommand : ICommand
{
    private Light _light;

    public LightOnCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.TurnOn();
    }
}

class LightOffCommand : ICommand
{
    private Light _light;

    public LightOffCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.TurnOff();
    }
}

// Receiver
class Light
{
    public void TurnOn()
    {
        Console.WriteLine("Light is ON");
    }

    public void TurnOff()
    {
        Console.WriteLine("Light is OFF");
    }
}

// Invoker
class RemoteControl
{
    private ICommand _command;

    public void SetCommand(ICommand command)
    {
        _command = command;
    }

    public void PressButton()
    {
        _command.Execute();
    }
}

class Program
{
    static void Main()
    {
        //________________EXAMPLE 1_____________
        TextEditor editor = new TextEditor();
        ITextCommand addCommand = new AddTextCommand(editor, "Hello Ali!");
        ITextCommand deleteCommand = new DeleteTextCommand(editor);
        User user = new User();
        user.SetCommand(addCommand);
        user.ExecuteCommand(); 
        user.SetCommand(deleteCommand);
        user.ExecuteCommand(); 
        Console.WriteLine();
        //________________EXAMPLE 2_____________
        Light light = new Light();
        ICommand lightOnCommand = new LightOnCommand(light);
        ICommand lightOffCommand = new LightOffCommand(light);
        RemoteControl remoteControl = new RemoteControl();
        remoteControl.SetCommand(lightOnCommand);
        remoteControl.PressButton(); // Turns the light ON
        remoteControl.SetCommand(lightOffCommand);
        remoteControl.PressButton(); // Turns the light OFF
        
    }
}
