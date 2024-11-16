using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class MessengerDestination : IDestination
{
    public MessengerDestination(IDestination messengerAdapter)
    {
        _messengerAdapter = messengerAdapter;
    }

    public void ReceiveMessage(IMessage message)
    {
        _messengerAdapter.ReceiveMessage(message);
    }

    private readonly IDestination _messengerAdapter;
}