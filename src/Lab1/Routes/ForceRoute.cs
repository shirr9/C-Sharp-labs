using Itmo.ObjectOrientedProgramming.Lab1.ResultType;
using Itmo.ObjectOrientedProgramming.Lab1.Trains;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public class ForceRoute : IRouteSection
{
    public double Distance { get; }

    public double Force { get; }

    public ForceRoute(double distance, double force)
    {
        if (distance < 0)
        {
            throw new ArgumentException("Distance cannot be negative");
        }

        Distance = distance;
        Force = force;
    }

    public RouteResult MoveTrain(Train train)
    {
        if (!train.ApplyForce(Force))
        {
            return new RouteResult.ForceLimitReached();
        }

        return train.CalculateTotalTime(Distance);
    }
}