using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

public interface ISubject : IEntity
{
    public Guid? ParentId { get; }

    public string Name { get; protected set; }

    public User Author { get; }

    public AssessmentType Type { get; }

    public int PointsCount { get; }

    void AddLectureMaterial(ILectureMaterials lectureMaterials);

    public bool TryModify(User user, string name);

    public ISubject Clone();

    public bool IsSubjectScoreComplete();
}