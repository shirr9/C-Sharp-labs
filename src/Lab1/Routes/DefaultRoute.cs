using Itmo.ObjectOrientedProgramming.Lab1.ResultType;
using Itmo.ObjectOrientedProgramming.Lab1.Trains;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public class DefaultRoute : IRouteSection
{
    public double Distance { get; }

    public DefaultRoute(double distance)
    {
        if (distance < 0)
        {
            throw new ArgumentException("Distance cannot be negative");
        }

        Distance = distance;
    }

    public RouteResult MoveTrain(Train train)
    {
        return train.CalculateTotalTime(Distance);
    }
}