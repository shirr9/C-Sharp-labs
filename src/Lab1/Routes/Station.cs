using Itmo.ObjectOrientedProgramming.Lab1.ResultType;
using Itmo.ObjectOrientedProgramming.Lab1.Trains;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public class Station : IRouteSection
{
    public double Distance { get; }

    public double Traffic { get; }

    public double SpeedLimit { get; }

    public Station(double traffic, double speedLimit)
    {
        if (traffic < 0)
        {
            throw new ArgumentException("Traffic cannot be negative");
        }

        if (speedLimit < 0)
        {
            throw new ArgumentException("Speed limit cannot be negative");
        }

        Distance = 0;
        Traffic = traffic;
        SpeedLimit = speedLimit;
    }

    public RouteResult MoveTrain(Train train)
    {
        if (train.Speed > SpeedLimit)
        {
            return new RouteResult.SpeedLimitReached();
        }

        return new RouteResult.Success(Traffic);
    }
}