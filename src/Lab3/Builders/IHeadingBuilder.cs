namespace Itmo.ObjectOrientedProgramming.Lab3.Builders;

public interface IHeadingBuilder
{
    IBodyBuilder WithHeading(string heading);
}