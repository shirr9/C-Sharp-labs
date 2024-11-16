namespace Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

public interface ITopic
{
    string Name { get; }

    void SendMessage(IMessage message);

    void AddDestination(IDestination destination);
}