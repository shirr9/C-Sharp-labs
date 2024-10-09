using Itmo.ObjectOrientedProgramming.Lab1.ResultType;
using Itmo.ObjectOrientedProgramming.Lab1.Trains;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public class WholeRoute
{
    public double SpeedLimit { get; }

    public Train MyTrain { get; }

    public WholeRoute(double speedLimit, Train train)
    {
        SpeedLimit = speedLimit;
        MyTrain = train;
    }

    private readonly List<IRouteSection> routeSections = new List<IRouteSection>();

    public void AddRouteSection(IRouteSection routeSection) => routeSections.Add(routeSection);

    public RouteResult DriveTheRoute()
    {
        if (routeSections.Count == 0)
        {
            throw new Exception("No route sections");
        }

        double resultTime = 0;

        foreach (IRouteSection section in routeSections)
        {
            RouteResult result = section.MoveTrain(MyTrain);
            if (result is RouteResult.Success successResult)
            {
                resultTime += successResult.Time;
            }
            else
            {
                return result;
            }
        }

        if (MyTrain.Speed > SpeedLimit)
        {
            return new RouteResult.SpeedLimitReached();
        }

        return new RouteResult.Success(resultTime);
    }
}