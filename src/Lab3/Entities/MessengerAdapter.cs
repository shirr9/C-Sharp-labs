using Itmo.ObjectOrientedProgramming.Lab3.External.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class MessengerAdapter : IDestination
{
    public MessengerAdapter(Messenger messenger)
    {
        _messenger = messenger;
    }

    private readonly Messenger _messenger;

    public void ReceiveMessage(IMessage message)
    {
        _messenger.AcceptMessage(message);
    }
}