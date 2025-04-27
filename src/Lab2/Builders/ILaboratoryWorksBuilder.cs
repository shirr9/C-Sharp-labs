using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public interface ILaboratoryWorksBuilder
{
    ISubjectBuilder WithLaboratoryWork(ILaboratoryWork laboratoryWork);
}