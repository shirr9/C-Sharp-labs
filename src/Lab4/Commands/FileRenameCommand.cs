using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Systems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileRenameCommand : ICommand
{
    private readonly string _newName;

    private string _path;

    public FileRenameCommand(string path, string newName)
    {
        _path = path;
        _newName = newName;
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

        programSystem.ConnectedFileSystem.RenameFile(_path, _newName);
    }
}