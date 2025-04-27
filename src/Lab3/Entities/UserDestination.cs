using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class UserDestination : IDestination
{
    public UserDestination(IUser user)
    {
        _user = user;
    }

    public void ReceiveMessage(IMessage message)
    {
        _user.ReceiveMessage(message);
    }

    private readonly IUser _user;
}