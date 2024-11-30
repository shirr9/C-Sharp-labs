using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Printer;
using Itmo.ObjectOrientedProgramming.Lab4.Systems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileShowCommand : ICommand
{
    private readonly string _mode;

    private string _path;

    public FileShowCommand(string path, string mode)
    {
        _path = path;
        _mode = mode;
    }

    public void Execute(IProgramSystem programSystem)
    {
        IPrinter? printer = programSystem.TryFindPrinter(_mode);
        if (printer is null)
        {
            throw new InvalidMode("Invalid mode");
        }

        if (programSystem.ConnectedFileSystem is null)
        {
            throw new FileSystemNotConnectedException("System is not connected.");
        }

        string current_path = programSystem.ConnectedFileSystem.Address;
        if (!Path.IsPathRooted(_path))
        {
            _path = Path.Combine(current_path, _path);
        }

        printer.PrintFile(_path);
    }
}