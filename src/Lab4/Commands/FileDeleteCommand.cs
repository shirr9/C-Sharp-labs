using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Systems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileDeleteCommand : ICommand
{
    private string _path;

    public FileDeleteCommand(string path)
    {
        _path = path;
    }

    public void Execute(IProgramSystem programSystem)
    {
        if (programSystem.ConnectedFileSystem is null)
        {
            throw new FileSystemNotConnectedException("System is not connected.");
        }

        string current_path = programSystem.ConnectedFileSystem.Address;
        if (!Path.IsPathRooted(_path))
        {
            _path = Path.Combine(current_path, _path);
        }

        programSystem.ConnectedFileSystem.DeleteFile(_path);
    }
}