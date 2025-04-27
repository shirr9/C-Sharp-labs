using Itmo.ObjectOrientedProgramming.Lab3.External.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class DisplayAdapter : IDestination
{
    private readonly IDisplay _display;

    public DisplayAdapter(IDisplay display)
    {
        _display = display;
    }

    public void ReceiveMessage(IMessage message)
    {
        _display.ShowMessage(message.Heading);
    }
}