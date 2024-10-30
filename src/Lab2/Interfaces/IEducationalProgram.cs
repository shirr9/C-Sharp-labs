using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

public interface IEducationalProgram : IEntity
{
    string Name { get; }

    User ProgramManager { get; }

    Dictionary<int, List<ISubject>> Subjects { get; }

    void AddSubject(int semester, ISubject subject);
}