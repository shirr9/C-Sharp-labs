using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Factories;

public abstract class EducationalProgramFactory
{
    public abstract IEducationalProgram CreateEducationalProgram(string name, User programManager);
}