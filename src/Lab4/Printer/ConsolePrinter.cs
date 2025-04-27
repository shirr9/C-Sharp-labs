namespace Itmo.ObjectOrientedProgramming.Lab4.Printer;

public class ConsolePrinter : IPrinter
{
    public ConsolePrinter()
    {
        FileSymbol = "[file] ";
        FolderSymbol = "[folder] ";
    }

    public ConsolePrinter(string fileDesignation, string folderDesignation)
    {
        FileSymbol = fileDesignation;
        FolderSymbol = folderDesignation;
    }

    public string FileSymbol { get; set; }

    public string FolderSymbol { get; set; }

    public string IndentationSymbol { get; set; } = "  ";

    public void PrintFile(string path)
    {
        try
        {
            string absolutePath = Path.GetFullPath(path);

            if (!File.Exists(absolutePath))
            {
                Console.WriteLine($"File not found: {absolutePath}");
                return;
            }

            string fileContent = File.ReadAllText(absolutePath);
            Console.WriteLine(fileContent);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
        }
    }

    public void PrintFolder(string path, int depth, int currentDepth, string prefix)
    {
        var dirInfo = new DirectoryInfo(path);

        Console.WriteLine($"{prefix}{FolderSymbol} {dirInfo.Name}");

        if (currentDepth > depth) return;

        DirectoryInfo[] directories = dirInfo.GetDirectories();
        FileInfo[] files = dirInfo.GetFiles();

        foreach (FileInfo file in files)
        {
            PrintFileName(file.FullName, prefix + IndentationSymbol);
        }

        foreach (DirectoryInfo subDir in directories)
        {
            PrintFolder(subDir.FullName, depth, currentDepth + 1, prefix + IndentationSymbol);
        }
    }

    public void PrintCommand(string message)
    {
        Console.WriteLine(message);
    }

    private void PrintFileName(string path, string prefix)
    {
        var fileInfo = new FileInfo(path);
        Console.WriteLine($"{prefix}{FileSymbol} {fileInfo.Name}");
    }
}