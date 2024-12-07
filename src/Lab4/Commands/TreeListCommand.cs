using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Printer;
using Itmo.ObjectOrientedProgramming.Lab4.Systems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeListCommand : ICommand
{
    private const int _defaultDepth = 1;

    private readonly int _depth;

    public TreeListCommand(int depth)
    {
        _depth = depth;
    }

    public TreeListCommand()
    {
        _depth = _defaultDepth;
    }

    public void Execute(IProgramSystem programSystem)
    {
        IPrinter? printer = programSystem.TryFindPrinter("console");
        if (printer is null)
        {
            throw new InvalidMode("invalid mode");
        }

        if (programSystem.ConnectedFileSystem is null)
        {
            throw new FileSystemNotConnectedException("System is not connected.");
        }

        string path = programSystem.ConnectedFileSystem.Address;
        printer.PrintFolder(path, _depth, 1, string.Empty);
    }
}