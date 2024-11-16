using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class FilterMessagesDecorator : IDestination
{
    private readonly IDestination _destination;

    private readonly int _importanceDestination;

    public FilterMessagesDecorator(IDestination destination, int importanceDestination)
    {
        _destination = destination;
        _importanceDestination = importanceDestination;
    }

    public void ReceiveMessage(IMessage message)
    {
        if (message.Importance < _importanceDestination) return;
        _destination.ReceiveMessage(message);
    }
}