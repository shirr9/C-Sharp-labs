using Itmo.ObjectOrientedProgramming.Lab2.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public interface ITypeBuilder
{
    IPointsCountBuilder WithType(AssessmentType type);
}