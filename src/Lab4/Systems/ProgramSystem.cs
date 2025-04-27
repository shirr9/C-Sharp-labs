using Itmo.ObjectOrientedProgramming.Lab4.Factories;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Printer;

namespace Itmo.ObjectOrientedProgramming.Lab4.Systems;

public class ProgramSystem : IProgramSystem
{
    private readonly List<IFileSystemFactory> _fileSystemFactories;

    private readonly List<IPrinterFactory> _printerFactories;

    public ProgramSystem(IEnumerable<IFileSystemFactory> fileSystemFactories, IEnumerable<IPrinterFactory> printerFactories)
    {
        _fileSystemFactories = new List<IFileSystemFactory>();
        _fileSystemFactories.AddRange(fileSystemFactories);
        _printerFactories = new List<IPrinterFactory>();
        _printerFactories.AddRange(printerFactories);
    }

    public IFileSystem? ConnectedFileSystem { get; private set; }

    public void ConnectSystem(string address, string mode)
    {
        IFileSystemFactory? factory = _fileSystemFactories.Find(f => f.FileSystemMode == mode);

        if (factory == null)
        {
            throw new ArgumentException("Invalid mode");
        }

        ConnectedFileSystem = factory.CreateFileSystem(address);

        if (!Path.IsPathRooted(address))
        {
            Console.WriteLine("This is not absolute path");
            return;
        }

        if (!Directory.Exists(address))
        {
            Console.WriteLine("There is no such directory: " + address);
            return;
        }

        Console.WriteLine($"connected successfully: {ConnectedFileSystem.Address}");
    }

    public void DisconnectSystem()
    {
        ConnectedFileSystem = null;
        Console.WriteLine("Disconnecting...");
    }

    public IPrinter? TryFindPrinter(string mode)
    {
        IPrinterFactory? factory = _printerFactories.Find(f => f.PrinterMode == mode);
        if (factory == null)
        {
            return null;
        }

        return factory.CreatePrinter();
    }
}