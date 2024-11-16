namespace Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

public interface IUser
{
    void ReceiveMessage(IMessage message);

    public bool TryReadMessage(IMessage message);

    bool IsMessageRead(IMessage message);

    public bool IsMessageReceived(IMessage message);
}