namespace Itmo.ObjectOrientedProgramming.Lab2.ResultType;

public abstract record ResultOfChange
{
    public abstract string Result { get; init; }

    public sealed record Success : ResultOfChange
    {
        public override string Result { get; init; } = "Success: changed successfully";
    }

    public sealed record IncorrectAuthor : ResultOfChange
    {
        public override string Result { get; init; } = "Failure: incorrect author";
    }
}