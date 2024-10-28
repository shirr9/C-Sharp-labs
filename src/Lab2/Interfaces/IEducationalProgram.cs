using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

public interface IEducationalProgram : IEntity
{
    public string Name { get; }

    public User ProgramManager { get; }

    public Dictionary<int, List<ISubject>> Subjects { get; }

    public void AddSubject(int semester, ISubject subject);
}