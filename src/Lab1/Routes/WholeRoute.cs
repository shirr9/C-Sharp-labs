using Itmo.ObjectOrientedProgramming.Lab1.ResultType;
using Itmo.ObjectOrientedProgramming.Lab1.Trains;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public class WholeRoute
{
    private double SpeedLimit { get; }

    private readonly Train _train;

    public WholeRoute(double speedLimit, Train train)
    {
        SpeedLimit = speedLimit;
        _train = train;
    }

    private readonly List<IRouteSection> _routeSections = new List<IRouteSection>();

    public void AddRouteSection(IRouteSection routeSection) => _routeSections.Add(routeSection);

    public RouteResult DriveTheRoute()
    {
        if (_routeSections.Count == 0)
        {
            return new RouteResult.ZeroRouteSections();
        }

        double resultTime = 0;

        foreach (IRouteSection section in _routeSections)
        {
            RouteResult result = section.MoveTrain(_train);
            if (result is RouteResult.Success successResult)
            {
                resultTime += successResult.Time;
            }
            else
            {
                return result;
            }
        }

        if (_train.Speed > SpeedLimit)
        {
            return new RouteResult.SpeedLimitReached();
        }

        return new RouteResult.Success(resultTime);
    }
}