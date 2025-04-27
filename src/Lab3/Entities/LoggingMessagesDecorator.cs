using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class LoggingMessagesDecorator : IDestination
{
    private readonly IDestination _destination;

    private readonly ILogger _logger;

    public LoggingMessagesDecorator(IDestination destination, ILogger logger)
    {
        _destination = destination;
        _logger = logger;
    }

    public void ReceiveMessage(IMessage message)
    {
        _logger.Log(message.Id.ToString());
        _destination.ReceiveMessage(message);
    }
}