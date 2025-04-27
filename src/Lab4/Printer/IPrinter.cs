namespace Itmo.ObjectOrientedProgramming.Lab4.Printer;

public interface IPrinter
{
    string FileSymbol { get; set; }

    string FolderSymbol { get; set; }

    void PrintFile(string path);

    void PrintFolder(string path, int depth, int currentDepth, string prefix);

    void PrintCommand(string message);
}