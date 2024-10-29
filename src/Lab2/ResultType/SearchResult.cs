using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.ResultType;

public abstract record SearchResult
{
    public abstract string Result { get; init; }

    public sealed record Success(IEntity Entity) : SearchResult
    {
        public override string Result { get; init; } = "Success: Entity found successfully";
    }

    public sealed record EntityAbsent : SearchResult
    {
        public override string Result { get; init; } = "Failure: Entity not found";
    }
}