namespace Itmo.ObjectOrientedProgramming.Lab1.ResultType;

public abstract record RouteResult
{
    public abstract string Result { get; init; }

    public sealed record Success(double Time) : RouteResult
    {
        public override string Result { get; init; } = $"Success: Route completed successfully at time: {Time}";
    }

    public sealed record ForceLimitReached : RouteResult
    {
        public override string Result { get; init; } = "Failure: Force limit reached";
    }

    public sealed record NegativeSpeed : RouteResult
    {
        public override string Result { get; init; } = "Failure: Speed became negative";
    }

    public sealed record ZeroAccelerationAndSpeed : RouteResult
    {
        public override string Result { get; init; } = "Failure: Acceleration and speed are zero";
    }

    public sealed record SpeedLimitReached : RouteResult
    {
        public override string Result { get; init; } = "Failure: Speed limit reached";
    }

    public sealed record ZeroRouteSections : RouteResult
    {
        public override string Result { get; init; } = "Failure: No route sections";
    }
}