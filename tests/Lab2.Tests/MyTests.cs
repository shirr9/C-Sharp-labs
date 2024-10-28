using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.ResultType;
using Xunit;

namespace Lab2.Tests;

public class MyTests
{
    [Fact]
    public void TryModifySubjectByAuthor()
    {
        var author = new User("Zhenya");

        Subject subject = Subject.Builder
            .WithName("Math")
            .WithAuthor(author)
            .WithType(AssessmentType.Exam)
            .WithPointsCount(20)
            .WithLaboratoryWork(new LaboratoryWork("lab1", author, "description", 80, "Criteria"))
            .Build();
        bool result = subject.TryModify(author, "Physics") is ResultOfChange.Success;
        Assert.True(result);
    }

    [Fact]
    public void TryModifySubjectNotByAuthor()
    {
        var author1 = new User("Zhenya");
        var author2 = new User("Sima");

        Subject subject = Subject.Builder
            .WithName("Math")
            .WithAuthor(author1)
            .WithType(AssessmentType.Exam)
            .WithPointsCount(20)
            .WithLaboratoryWork(new LaboratoryWork("lab1", author1, "description", 80, "Criteria"))
            .Build();
        bool result = subject.TryModify(author2, "Physics") is ResultOfChange.IncorrectAuthor;
        Assert.True(result);
    }

    [Fact]
    public void TryModifyLaboratoryWorkByAuthor()
    {
        var author = new User("Zhenya");
        var laboratoryWork = new LaboratoryWork("lab1", author, "description", 80, "Criteria");
        bool result = laboratoryWork.TryModify(author, "lab", "new description") is ResultOfChange.Success;
        Assert.True(result);
    }

    [Fact]
    public void TryModifyLaboratoryWorkNotByAuthor()
    {
        var author1 = new User("Zhenya");
        var author2 = new User("Sima");
        var laboratoryWork = new LaboratoryWork("lab1", author1, "description", 80, "Criteria");
        bool result = laboratoryWork.TryModify(author2, "lab", "new description") is ResultOfChange.IncorrectAuthor;
        Assert.True(result);
    }

    [Fact]
    public void TryModifyLectureMaterialsByAuthor()
    {
        var author = new User("Zhenya");
        var lectureMaterials = new LectureMaterials("lecture1", author, "description",  "Content");
        bool result = lectureMaterials.TryModify(author, "lab", "new description", "new content") is ResultOfChange.Success;
        Assert.True(result);
    }

    [Fact]
    public void TryModifyLectureMaterialsNotByAuthor()
    {
        var author1 = new User("Zhenya");
        var author2 = new User("Sima");
        var lectureMaterials = new LectureMaterials("lecture1", author1, "description",  "Content");
        bool result = lectureMaterials.TryModify(author2, "lab", "new description", "new content") is ResultOfChange.IncorrectAuthor;
        Assert.True(result);
    }

    [Fact]
    public void TryCloneLaboratoryWorkCorrectly()
    {
        var author = new User("Zhenya");
        var laboratoryWork = new LaboratoryWork("lab1", author, "description", 80, "Criteria");
        ILaboratoryWork clonedLaboratoryWork = laboratoryWork.Clone();
        bool result = clonedLaboratoryWork.ParentId == laboratoryWork.Id;
        Assert.True(result);
    }

    [Fact]
    public void TryCloneLectureMaterialsCorrectly()
    {
        var author = new User("Zhenya");
        var lectureMaterials = new LectureMaterials("lecture1", author, "description",  "Content");
        ILectureMaterials clonedLectureMaterials = lectureMaterials.Clone();
        bool result = clonedLectureMaterials.ParentId == lectureMaterials.Id;
        Assert.True(result);
    }

    [Fact]
    public void TryCloneSubjectCorrectly()
    {
        var author = new User("Zhenya");
        Subject subject = Subject.Builder
            .WithName("Math")
            .WithAuthor(author)
            .WithType(AssessmentType.Exam)
            .WithPointsCount(20)
            .WithLaboratoryWork(new LaboratoryWork("lab1", author, "description", 80, "Criteria"))
            .Build();
        ISubject clonedSubject = subject.Clone();
        bool result = clonedSubject.ParentId == subject.Id;
        Assert.True(result);
    }

    [Fact]
    public void TryCreateSubjectWithIncorrectPointsCount()
    {
        var author = new User("Zhenya");

        Assert.Throws<InvalidSubjectScoreException>(() =>
        {
            Subject subject = Subject.Builder
                .WithName("Math")
                .WithAuthor(author)
                .WithType(AssessmentType.Exam)
                .WithPointsCount(20)
                .WithLaboratoryWork(new LaboratoryWork("lab1", author, "description", 20, "Criteria"))
                .Build();
        });
    }
}