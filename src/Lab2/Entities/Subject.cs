using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.ResultType;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Subject : ISubject
{
    private Subject(string name, User author, AssessmentType type, int pointsCount, List<ILaboratoryWork> laboratoryWorks, List<ILectureMaterials> lectureMaterials)
    {
        Id = Guid.NewGuid();
        ParentId = null;
        Name = name;
        Author = author;
        Type = type;
        PointsCount = pointsCount;
        foreach (ILaboratoryWork laboratory in laboratoryWorks)
        {
            _laboratoryWorks.Add(laboratory);
        }

        foreach (ILectureMaterials lectureMaterial in lectureMaterials)
        {
            _lectureMaterials.Add(lectureMaterial);
        }
    }

    private Subject(Subject sourceSubject)
    {
        Id = Guid.NewGuid();
        ParentId = sourceSubject.Id;
        Name = sourceSubject.Name;
        Author = sourceSubject.Author;
        Type = sourceSubject.Type;
        PointsCount = sourceSubject.PointsCount;

        _laboratoryWorks = sourceSubject._laboratoryWorks
            .Select(lw => lw.Clone())
            .ToList();

        _lectureMaterials = sourceSubject._lectureMaterials
            .Select(lm => lm.Clone())
            .ToList();
    }

    public Guid Id { get; }

    public Guid? ParentId { get; }

    public string Name { get; set; }

    public User Author { get; }

    public AssessmentType Type { get; }

    public int PointsCount { get; }

    private readonly List<ILaboratoryWork> _laboratoryWorks = new();

    private readonly List<ILectureMaterials> _lectureMaterials = new();

    public void AddLectureMaterial(ILectureMaterials lectureMaterials)
    {
        _lectureMaterials.Add(lectureMaterials);
    }

    public ResultOfChange TryModify(User user, string name)
    {
        if (user.Id != Author.Id || user.Name != Author.Name)
        {
            return new ResultOfChange.IncorrectAuthor();
        }

        Name = name;
        return new ResultOfChange.Success();
    }

    public ISubject Clone()
    {
        return new Subject(this);
    }

    public bool IsSubjectScoreComplete()
    {
        int totalLabPointsCount = _laboratoryWorks.Sum(lw => lw.PointsCount);
        if (Type == AssessmentType.Exam)
        {
            return totalLabPointsCount + PointsCount == 100;
        }

        return totalLabPointsCount == 100;
    }

    // BUILDER
    public static INameBuilder Builder => new SubjectBuilder();

    private class SubjectBuilder : INameBuilder, IAuthorBuilder, ITypeBuilder, IPointsCountBuilder, ILaboratoryWorksBuilder, ISubjectBuilder
    {
        private static User? _defaultAuthor;

        private readonly List<ILaboratoryWork> _laboratoryWorksCollection = [];

        private readonly List<ILectureMaterials> _lectureMaterialsCollection = [];

        private string? _name;

        private User? _author;

        private AssessmentType _type;

        private int _pointsCount;

        public IAuthorBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public ITypeBuilder WithAuthor(User author)
        {
            _author = author;
            return this;
        }

        public IPointsCountBuilder WithType(AssessmentType type)
        {
            _type = type;
            return this;
        }

        public ILaboratoryWorksBuilder WithPointsCount(int pointsCount)
        {
            _pointsCount = pointsCount;
            return this;
        }

        public void SetDefaultAuthor(User author)
        {
             _defaultAuthor = author;
        }

        public ISubjectBuilder WithLaboratoryWork(ILaboratoryWork laboratoryWork)
        {
            _laboratoryWorksCollection.Add(laboratoryWork);
            return this;
        }

        public ISubjectBuilder WithLectureMaterials(ILectureMaterials lectureMaterials)
        {
            _lectureMaterialsCollection.Add(lectureMaterials);
            return this;
        }

        public Subject Build()
        {
            User? authorToUse = _author ?? _defaultAuthor;

            if (_name == null) throw new MissingRequiredFieldException("Name");
            if (authorToUse == null) throw new MissingRequiredFieldException("Author");

            var subject = new Subject(_name, authorToUse, _type, _pointsCount, _laboratoryWorksCollection, _lectureMaterialsCollection);
            if (!subject.IsSubjectScoreComplete())
            {
                throw new InvalidSubjectScoreException("Subject points must be 100");
            }

            return subject;
        }
    }
}