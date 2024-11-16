namespace Itmo.ObjectOrientedProgramming.Lab3.Builders;

public interface IBodyBuilder
{
    IImportanceBuilder WithBody(string body);
}