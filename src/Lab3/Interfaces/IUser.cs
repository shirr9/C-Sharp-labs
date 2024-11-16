namespace Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

public interface IUser
{
    void ReceiveMessage(IMessage message);

    bool TryReadMessage(IMessage message);

    bool IsMessageRead(IMessage message);

    bool IsMessageReceived(IMessage message);
}