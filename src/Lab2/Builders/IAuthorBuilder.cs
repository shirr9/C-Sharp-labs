using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public interface IAuthorBuilder
{
    ITypeBuilder WithAuthor(User author);
}