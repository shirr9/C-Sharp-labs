using Itmo.ObjectOrientedProgramming.Lab3.External.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class MessengerLoggerDecorator : IMessenger
{
    private readonly ILogger _logger;

    private readonly IMessenger _messenger;

    public MessengerLoggerDecorator(IMessenger messenger, ILogger logger)
    {
        _logger = logger;
        _messenger = messenger;
    }

    public void AcceptMessage(IMessage message)
    {
        _messenger.AcceptMessage(message);
        _logger.Log(message.Id.ToString() + " from Messenger");
    }

    public void DisplayText()
    {
        _messenger.DisplayText();
    }
}