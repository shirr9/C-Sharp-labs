using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class DisplayDestination : IDestination
{
    private readonly IDestination _displayAdapter;

    public DisplayDestination(IDestination displayAdapter)
    {
        _displayAdapter = displayAdapter;
    }

    public void ReceiveMessage(IMessage message)
    {
        _displayAdapter.ReceiveMessage(message);
    }
}