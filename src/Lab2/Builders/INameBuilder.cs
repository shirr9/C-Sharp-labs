namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public interface INameBuilder
{
    IAuthorBuilder WithName(string name);
}