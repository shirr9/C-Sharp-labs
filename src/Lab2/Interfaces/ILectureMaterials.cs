using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.ResultType;

namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

public interface ILectureMaterials : IEntity
{
    public Guid? ParentId { get; }

    public string Name { get; }

    public User Author { get; }

    public string Description { get; }

    public string Content { get; }

    public ResultOfChange TryModify(User user, string name, string description, string content);

    public ILectureMaterials Clone();
}