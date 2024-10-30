using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

public interface ILectureMaterials : IEntity
{
    Guid? ParentId { get; }

    string Name { get; }

    User Author { get; }

    string Description { get; }

    string Content { get; }

    bool TryModifyName(User user, string name);

    bool TryModifyDescription(User user, string description);

    bool TryModifyContent(User user, string content);

    ILectureMaterials Clone();
}