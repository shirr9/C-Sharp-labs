namespace Itmo.ObjectOrientedProgramming.Lab3.Builders;

public interface IImportanceBuilder
{
    IMessageBuilder WithImportance(int importance);
}