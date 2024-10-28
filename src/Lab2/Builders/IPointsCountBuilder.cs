namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public interface IPointsCountBuilder
{
    ILaboratoryWorksBuilder WithPointsCount(int pointsCount);
}