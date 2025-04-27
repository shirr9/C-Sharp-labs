namespace Itmo.ObjectOrientedProgramming.Lab2.ResultType;

public abstract record ResultOfCreation
{
    public abstract string Result { get; init; }

    public sealed record Success : ResultOfCreation
    {
        public override string Result { get; init; } = "Success: created successfully";
    }

    public sealed record IncorrectLaboratoryPointsCount : ResultOfCreation
    {
        public override string Result { get; init; } = "Failure: The total score for laboratory work is not 100";
    }
}