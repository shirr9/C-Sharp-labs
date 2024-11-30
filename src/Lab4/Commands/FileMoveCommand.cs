using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Systems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileMoveCommand : ICommand
{
    private string _sourcePath;

    private string _destinationPath;

    public FileMoveCommand(string sourcePath, string destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public void Execute(IProgramSystem programSystem)
    {
        if (programSystem.ConnectedFileSystem is null)
        {
            throw new FileSystemNotConnectedException("System is not connected.");
        }

        string current_path = programSystem.ConnectedFileSystem.Address;
        if (!Path.IsPathRooted(_sourcePath))
        {
            _sourcePath = Path.Combine(current_path, _sourcePath);
        }

        if (!Path.IsPathRooted(_destinationPath))
        {
            _destinationPath = Path.Combine(current_path, _destinationPath);
        }

        programSystem
            .ConnectedFileSystem
            .MoveFile(_sourcePath, _destinationPath + Path.DirectorySeparatorChar + Path.GetFileName(_sourcePath));
    }
}