using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class User : IUser
{
    public Guid Id { get; }

    public string Name { get; }

    public User(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}