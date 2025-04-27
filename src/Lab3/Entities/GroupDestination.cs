using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class GroupDestination : IDestination
{
    public GroupDestination(IEnumerable<IDestination> destinations)
    {
        _destinations.AddRange(destinations);
    }

    public GroupDestination()
    {
    }

    public void AddDestination(IDestination destination)
    {
        _destinations.Add(destination);
    }

    public void ReceiveMessage(IMessage message)
    {
        foreach (IDestination destination in _destinations)
        {
            destination.ReceiveMessage(message);
        }
    }

    private readonly List<IDestination> _destinations = [];
}