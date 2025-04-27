using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.External.Interfaces;

public interface IMessenger
{
    void AcceptMessage(IMessage message);

    void DisplayText();
}