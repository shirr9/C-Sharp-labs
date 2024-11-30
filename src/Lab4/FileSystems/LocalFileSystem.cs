using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

public class LocalFileSystem : IFileSystem
{
    public LocalFileSystem(string address)
    {
        Address = address;
        Mode = "local";
        Id = Guid.NewGuid();
    }

    public Guid Id { get; }

    public string Mode { get; }

    public string Address { get; set; }

    public void MoveFile(string sourcePath, string destinationPath)
    {
        sourcePath = Path.GetFullPath(sourcePath);
        destinationPath = Path.GetFullPath(destinationPath);

        try
        {
            File.Move(sourcePath, destinationPath);
            Console.WriteLine("File moved successfully");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Fault: {ex.Message}");
        }
    }

    public void CopyFile(string sourcePath, string destinationPath)
    {
        sourcePath = Path.GetFullPath(sourcePath);
        destinationPath = Path.GetFullPath(destinationPath);

        string fileName = Path.GetFileName(sourcePath);
        string destination = Path.Combine(destinationPath, fileName);

        int counter = 1;
        while (File.Exists(destination))
        {
            string newFileName = Path.GetFileNameWithoutExtension(fileName) + $"({counter})" + Path.GetExtension(fileName);
            destination = Path.Combine(destinationPath, newFileName);
            counter++;
        }

        try
        {
            File.Copy(sourcePath, destination);
            Console.WriteLine($"File copied successfully");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Error copying file: {ex.Message}");
        }
    }

    public void DeleteFile(string path)
    {
        path = Path.GetFullPath(path);

        try
        {
            File.Delete(path);
            Console.WriteLine("File deleted successfully");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Fault: {ex.Message}");
        }
    }

    public void RenameFile(string path, string newName)
    {
        path = Path.GetFullPath(path);

        try
        {
            string? directory = Path.GetDirectoryName(path);
            if (directory == null)
            {
                throw new InvalidPathException("Invalid path");
            }

            string newFilePath = Path.Combine(directory, newName);

            if (!File.Exists(path))
            {
                throw new IOException($"File '{path}' does not exist.");
            }

            File.Move(path, newFilePath);
            Console.WriteLine($"File renamed to: {newFilePath}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Fault: {ex.Message}");
        }
        catch (InvalidPathException ex)
        {
            Console.WriteLine($"Invalid path: {ex.Message}");
        }
    }

    public void GotoDirectory(string path)
    {
        path = Path.GetFullPath(path);
        Address = path;
        Console.WriteLine($"Goto from: {path}");
    }
}