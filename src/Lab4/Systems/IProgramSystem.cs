using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Printer;

namespace Itmo.ObjectOrientedProgramming.Lab4.Systems;

public interface IProgramSystem
{
    IFileSystem? ConnectedFileSystem { get; }

    void ConnectSystem(string address, string mode);

    void DisconnectSystem();

    IPrinter? TryFindPrinter(string mode);
}