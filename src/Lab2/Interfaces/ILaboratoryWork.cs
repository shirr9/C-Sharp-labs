using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.ResultType;

namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

public interface ILaboratoryWork : IEntity
{
    public Guid? ParentId { get; }

    public string Name { get; }

    public User Author { get; }

    public string Description { get; }

    public int PointsCount { get; }

    public string EvaluationCriteria { get; }

    public ResultOfChange TryModify(User user, string name, string description);

    public ILaboratoryWork Clone();
}