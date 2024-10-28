using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class EducationalProgram : IEducationalProgram
{
    public EducationalProgram(string name, User programManager)
    {
        Id = Guid.NewGuid();
        Name = name;
        ProgramManager = programManager;
        Subjects = new Dictionary<int, List<ISubject>>();
    }

    public Guid Id { get; }

    public string Name { get; }

    public User ProgramManager { get; }

    public Dictionary<int, List<ISubject>> Subjects { get; }

    public void AddSubject(int semester, ISubject subject)
    {
        if (semester < 0)
        {
            throw new ArgumentException("The semester must be greater than 0.");
        }

        if (!Subjects.TryGetValue(semester, out List<ISubject>? subjects))
        {
            Subjects[semester] = new();
        }

        Subjects[semester].Add(subject);
    }
}