using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Printer;
using Itmo.ObjectOrientedProgramming.Lab4.Systems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeListCommand : ICommand
{
    private readonly int _depth;

    public TreeListCommand(int depth)
    {
        _depth = depth;
    }

    public TreeListCommand()
    {
        _depth = 1;
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
        printer.PrintFolder(path, _depth, _depth, string.Empty);
    }
}