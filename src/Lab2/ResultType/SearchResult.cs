using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.ResultType;

public abstract record SearchResult
{
    public abstract string Result { get; init; }

    public sealed record Success(User User) : SearchResult
    {
        public override string Result { get; init; } = "Success: User found successfully";
    }

    public sealed record UserAbsent : SearchResult
    {
        public override string Result { get; init; } = "Failure: User not found";
    }
}