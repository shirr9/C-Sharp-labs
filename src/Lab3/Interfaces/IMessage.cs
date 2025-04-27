namespace Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

public interface IMessage : IEquatable<IMessage>
{
    string Heading { get; }

    string Body { get; }

    int Importance { get; }

    Guid Id { get; }
}