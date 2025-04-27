using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public interface ISubjectBuilder
{
    ISubjectBuilder WithLectureMaterials(ILectureMaterials lectureMaterials);

    Subject Build();
}