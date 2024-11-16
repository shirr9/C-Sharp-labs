using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class User : IUser
{
    private readonly Dictionary<IMessage, bool> _userMessages = [];

    public void ReceiveMessage(IMessage message)
    {
        if (!_userMessages.TryAdd(message, false)) throw new ReceivingMessageException($"Message has already been received.");
    }

    public bool TryReadMessage(IMessage message)
    {
        if (_userMessages[message]) return false;
        _userMessages[message] = true;
        return true;
    }

    public bool IsMessageRead(IMessage message)
    {
        return _userMessages[message];
    }

    // ?????
    public bool IsMessageReceived(IMessage message)
    {
        return _userMessages.ContainsKey(message);
    }
}