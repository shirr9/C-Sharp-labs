using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class LaboratoryWork : ILaboratoryWork
{
    public Guid Id { get; }

    public Guid? ParentId { get; }

    public string Name { get; private set; }

    public User Author { get; }

    public string Description { get; private set; }

    public int PointsCount { get; }

    public string EvaluationCriteria { get; }

    public LaboratoryWork(string name, User author, string description, int pointsCount, string evaluationCriteria)
    {
        Id = Guid.NewGuid();
        ParentId = null;
        Name = name;
        Author = author;
        Description = description;
        PointsCount = pointsCount;
        EvaluationCriteria = evaluationCriteria;
    }

    private LaboratoryWork(LaboratoryWork sourceLaboratoryWork)
    {
        Id = Guid.NewGuid();
        ParentId = sourceLaboratoryWork.Id;
        Name = sourceLaboratoryWork.Name;
        Author = sourceLaboratoryWork.Author;
        Description = sourceLaboratoryWork.Description;
        PointsCount = sourceLaboratoryWork.PointsCount;
        EvaluationCriteria = sourceLaboratoryWork.EvaluationCriteria;
    }

    public bool TryModifyName(User user, string name)
    {
        if (user.Id != Author.Id || user.Name != Author.Name)
        {
            return false;
        }

        Name = name;
        return true;
    }

    public bool TryModifyDescription(User user, string description)
    {
        if (user.Id != Author.Id || user.Name != Author.Name)
        {
            return false;
        }

        Description = description;
        return true;
    }

    public ILaboratoryWork Clone()
    {
        return new LaboratoryWork(this);
    }
}