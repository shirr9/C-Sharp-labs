using Itmo.ObjectOrientedProgramming.Lab1.Routes;
using Itmo.ObjectOrientedProgramming.Lab1.Trains;
using Xunit;

namespace Lab1.Tests;

public class MyTests
{
    [Fact]
    public void Test1()
    {
        var train = new Train(1, 30, 1);
        var forceRoute = new ForceRoute(100, 20);
        var defaultRoute = new DefaultRoute(100);

        var road = new WholeRoute(100, train);
        road.AddRouteSection(forceRoute);
        road.AddRouteSection(defaultRoute);

        bool result = road.DriveTheRoute().Result();
        bool expectedResult = true;

        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void Test2()
    {
        var train = new Train(1, 30, 1);
        var forceRoute = new ForceRoute(100, 20);
        var defaultRoute = new DefaultRoute(100);

        var road = new WholeRoute(90, train);
        road.AddRouteSection(forceRoute);
        road.AddRouteSection(defaultRoute);

        bool result = road.DriveTheRoute().Result();
        bool expectedResult = false;

        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void Test3()
    {
        var train = new Train(1, 30, 1);
        var forceRoute = new ForceRoute(100, 20);
        var defaultRoute1 = new DefaultRoute(80);
        var station = new Station(10, 100);
        var defaultRoute2 = new DefaultRoute(100);

        var road = new WholeRoute(120, train);
        road.AddRouteSection(forceRoute);
        road.AddRouteSection(defaultRoute1);
        road.AddRouteSection(station);
        road.AddRouteSection(defaultRoute2);

        bool result = road.DriveTheRoute().Result();
        bool expectedResult = true;

        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void Test4()
    {
        var train = new Train(1, 30, 1);
        var forceRoute = new ForceRoute(100, 20);
        var station = new Station(10, 59);

        var road = new WholeRoute(120, train);
        road.AddRouteSection(forceRoute);
        road.AddRouteSection(station);

        bool result = road.DriveTheRoute().Result();
        bool expectedResult = false;

        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void Test5()
    {
        var train = new Train(1, 30, 1);
        var forceRoute = new ForceRoute(20, 20);
        var defaultRoute1 = new DefaultRoute(50);
        var station = new Station(10, 60);
        var defaultRoute2 = new DefaultRoute(50);

        var road = new WholeRoute(79, train);
        road.AddRouteSection(forceRoute);
        road.AddRouteSection(defaultRoute1);
        road.AddRouteSection(station);
        road.AddRouteSection(defaultRoute2);

        bool result = road.DriveTheRoute().Result();
        bool expectedResult = false;

        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void Test6()
    {
        var train = new Train(1, 150, 1);
        var forceRoute1 = new ForceRoute(60, 20);
        var defaultRoute1 = new DefaultRoute(50);
        var forceRoute2 = new ForceRoute(40, -20);
        var station = new Station(10, 40);
        var defaultRoute2 = new DefaultRoute(5);
        var forceRoute3 = new ForceRoute(100, 60);
        var defaultRoute3 = new DefaultRoute(200);
        var forceRoute4 = new ForceRoute(30, -100);

        var road = new WholeRoute(100, train);
        road.AddRouteSection(forceRoute1);
        road.AddRouteSection(defaultRoute1);
        road.AddRouteSection(forceRoute2);
        road.AddRouteSection(station);
        road.AddRouteSection(defaultRoute2);
        road.AddRouteSection(forceRoute3);
        road.AddRouteSection(defaultRoute3);
        road.AddRouteSection(forceRoute4);

        bool result = road.DriveTheRoute().Result();
        bool expectedResult = true;

        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void Test7()
    {
        var train = new Train(1, 150, 1);
        var defaultRoute = new DefaultRoute(50);

        var road = new WholeRoute(100, train);
        road.AddRouteSection(defaultRoute);

        bool result = road.DriveTheRoute().Result();
        bool expectedResult = false;

        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void Test8()
    {
        var train = new Train(1, 150, 1);
        var forceRoute1 = new ForceRoute(5, 5);
        var forceRoute2 = new ForceRoute(5, -10);

        var road = new WholeRoute(100, train);
        road.AddRouteSection(forceRoute1);
        road.AddRouteSection(forceRoute2);

        bool result = road.DriveTheRoute().Result();
        bool expectedResult = false;

        Assert.Equal(expectedResult, result);
    }
}
