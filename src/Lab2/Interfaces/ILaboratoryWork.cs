using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

public interface ILaboratoryWork : IEntity
{
    Guid? ParentId { get; }

    string Name { get; }

    User Author { get; }

    string Description { get; }

    int PointsCount { get; }

    string EvaluationCriteria { get; }

    bool TryModifyName(User user, string name);

    bool TryModifyDescription(User user, string description);

    ILaboratoryWork Clone();
}