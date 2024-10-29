using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class LectureMaterials : ILectureMaterials
{
    public Guid Id { get; }

    public Guid? ParentId { get; }

    public string Name { get; private set; }

    public User Author { get; }

    public string Description { get; private set; }

    public string Content { get; private set; }

    public LectureMaterials(string name, User author, string description, string content)
    {
        Id = Guid.NewGuid();
        ParentId = null;
        Name = name;
        Author = author;
        Description = description;
        Content = content;
    }

    private LectureMaterials(LectureMaterials sourceLectureMaterials)
    {
        Id = Guid.NewGuid();
        ParentId = sourceLectureMaterials.Id;
        Name = sourceLectureMaterials.Name;
        Author = sourceLectureMaterials.Author;
        Description = sourceLectureMaterials.Description;
        Content = sourceLectureMaterials.Content;
    }

    public bool TryModify(User user, string name, string description, string content)
    {
        if (user.Id != Author.Id || user.Name != Author.Name)
        {
            return false;
        }

        Name = name;
        Description = description;
        Content = content;
        return true;
    }

    public ILectureMaterials Clone()
    {
        var lectureMaterials = new LectureMaterials(this);
        return lectureMaterials;
    }
}