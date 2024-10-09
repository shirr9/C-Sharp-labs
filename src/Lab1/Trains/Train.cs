using Itmo.ObjectOrientedProgramming.Lab1.ResultType;

namespace Itmo.ObjectOrientedProgramming.Lab1.Trains;

public class Train
{
    public double Weight { get; }

    public double Speed { get; private set; }

    public double Acceleration { get; private set; }

    public double MaxForce { get; }

    public double Precision { get; }

    public Train(double weight, double maxForce, double precision)
    {
        if (weight < 0)
        {
            throw new ArgumentException("Weight cannot be negative");
        }

        if (precision < 0)
        {
            throw new ArgumentException("Precision cannot be negative");
        }

        Speed = 0;
        Acceleration = 0;
        Weight = weight;
        MaxForce = maxForce;
        Precision = precision;
    }

    public bool ApplyForce(double newForce)
    {
        if (Math.Abs(newForce) > MaxForce)
        {
            return false;
        }

        Acceleration = newForce / Weight;
        return true;
    }

    public RouteResult TotalTime(double allDistance)
    {
        double totalTime = 0;
        while (allDistance > 0)
        {
            Speed += Acceleration * Precision;

            if (Acceleration == 0 && Speed == 0)
            {
                return new RouteResult.ZeroAccelerationAndSpeed();
            }

            if (Speed < 0)
            {
                return new RouteResult.NegativeSpeed();
            }

            allDistance -= Speed * Precision;
            totalTime += Precision;
        }

        return new RouteResult.Success(totalTime);
    }
}