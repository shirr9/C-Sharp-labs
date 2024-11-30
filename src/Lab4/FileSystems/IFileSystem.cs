namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

public interface IFileSystem
{
    Guid Id { get; }

    string Mode { get; }

    string Address { get; set; }

    void MoveFile(string sourcePath, string destinationPath);

    void CopyFile(string sourcePath, string destinationPath);

    void DeleteFile(string path);

    void RenameFile(string path, string newName);

    void GotoDirectory(string path);

    void ConnectFileSystem(string address);
}