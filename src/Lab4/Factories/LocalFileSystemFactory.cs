using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Factories;

public class LocalFileSystemFactory : IFileSystemFactory
{
    public string FileSystemMode { get; } = "local";

    public IFileSystem CreateFileSystem(string address)
    {
        return new LocalFileSystem(address);
    }
}