using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

public interface ISubject : IEntity
{
    Guid? ParentId { get; }

    string Name { get; protected set; }

    User Author { get; }

    AssessmentType Type { get; }

    int PointsCount { get; }

    void AddLectureMaterial(ILectureMaterials lectureMaterials);

    bool TryModify(User user, string name);

    ISubject Clone();

    bool IsSubjectScoreComplete();
}