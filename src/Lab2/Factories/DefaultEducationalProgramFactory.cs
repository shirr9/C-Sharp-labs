using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Factories;

public class DefaultEducationalProgramFactory : EducationalProgramFactory
{
    public override IEducationalProgram CreateEducationalProgram(string name, User programManager)
    {
        return new EducationalProgram(name, programManager);
    }
}