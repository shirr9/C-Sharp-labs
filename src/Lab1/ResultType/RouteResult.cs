namespace Itmo.ObjectOrientedProgramming.Lab1.ResultType;

public abstract record RouteResult
{
    private RouteResult() { }

    public abstract bool Result();

    public abstract void PrintResult();

    public sealed record Success(double Time) : RouteResult
    {
        public override bool Result()
        {
            return true;
        }

        public override void PrintResult()
        {
            Console.WriteLine($"Success: Route completed successfully at time: {Time}");
        }
    }

    public sealed record ForceLimitReached : RouteResult
    {
        public override bool Result()
        {
            return false;
        }

        public override void PrintResult()
        {
            Console.WriteLine("Failure: Force limit reached");
        }
    }

    public sealed record NegativeSpeed : RouteResult
    {
        public override bool Result()
        {
            return false;
        }

        public override void PrintResult()
        {
            Console.WriteLine("Failure: Speed became negative");
        }
    }

    public sealed record ZeroAccelerationAndSpeed : RouteResult
    {
        public override bool Result()
        {
            return false;
        }

        public override void PrintResult()
        {
            Console.WriteLine("Failure: Acceleration and speed are zero");
        }
    }

    public sealed record SpeedLimitReached : RouteResult
    {
        public override bool Result()
        {
            return false;
        }

        public override void PrintResult()
        {
            Console.WriteLine($"Failure: Speed limit reached");
        }
    }
}