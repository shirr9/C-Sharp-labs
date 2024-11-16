using Itmo.ObjectOrientedProgramming.Lab3.External.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.External.Entities;

public class Messenger : IMessenger
{
    public void AcceptMessage(IMessage message)
    {
        _message = message.Heading;
        DisplayText();
    }

    public void DisplayText()
    {
        Console.WriteLine("Messenger: " + _message);
    }

    private string _message = string.Empty;
}