using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Topic : ITopic
{
    public Topic(string name, IEnumerable<IDestination> destinations)
    {
        Name = name;
        _destinations.AddRange(destinations);
    }

    public string Name { get; }

    public void SendMessage(IMessage message)
    {
        foreach (IDestination destination in _destinations)
        {
            destination.ReceiveMessage(message);
        }
    }

    public void AddDestination(IDestination destination)
    {
        _destinations.Add(destination);
    }

    private readonly List<IDestination> _destinations = [];
}
