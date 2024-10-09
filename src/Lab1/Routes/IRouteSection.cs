using Itmo.ObjectOrientedProgramming.Lab1.ResultType;
using Itmo.ObjectOrientedProgramming.Lab1.Trains;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public interface IRouteSection
{
    public double Distance { get; }

    public RouteResult MoveTrain(Train train);
}