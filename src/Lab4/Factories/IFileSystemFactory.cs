using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Factories;

public interface IFileSystemFactory
{
    string FileSystemMode { get; }

    IFileSystem CreateFileSystem(string address);
}