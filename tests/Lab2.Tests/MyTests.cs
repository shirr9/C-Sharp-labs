using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
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
        Assert.True(subject.TryModify(author, "Physics"));
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
        Assert.False(
            subject.TryModify(author2, "Physics"));
    }

    [Fact]
    public void TryModifyLaboratoryWorkByAuthor()
    {
        var author = new User("Zhenya");
        var laboratoryWork = new LaboratoryWork("lab1", author, "description", 80, "Criteria");
        Assert.True(laboratoryWork.TryModifyName(author, "lab"));
        Assert.True(laboratoryWork.TryModifyDescription(author, "description"));
    }

    [Fact]
    public void TryModifyLaboratoryWorkNotByAuthor()
    {
        var author1 = new User("Zhenya");
        var author2 = new User("Sima");
        var laboratoryWork = new LaboratoryWork("lab1", author1, "description", 80, "Criteria");
        Assert.False(laboratoryWork.TryModifyName(author2, "lab"));
        Assert.False(laboratoryWork.TryModifyDescription(author2, "new description"));
    }

    [Fact]
    public void TryModifyLectureMaterialsByAuthor()
    {
        var author = new User("Zhenya");
        var lectureMaterials = new LectureMaterials("lecture1", author, "description",  "Content");
        Assert.True(lectureMaterials.TryModifyName(author, "lab"));
        Assert.True(lectureMaterials.TryModifyDescription(author,  "new description"));
        Assert.True(lectureMaterials.TryModifyContent(author, "new content"));
    }

    [Fact]
    public void TryModifyLectureMaterialsNotByAuthor()
    {
        var author1 = new User("Zhenya");
        var author2 = new User("Sima");
        var lectureMaterials = new LectureMaterials("lecture1", author1, "description",  "Content");
        Assert.False(lectureMaterials.TryModifyName(author2, "lab"));
        Assert.False(lectureMaterials.TryModifyDescription(author2, "new description"));
        Assert.False(lectureMaterials.TryModifyContent(author2, "new content"));
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
                .WithLaboratoryWork(new LaboratoryWork("lab1", author, "description", 30, "Criteria"))
                .Build();
        });
    }
}