using Itmo.ObjectOrientedProgramming.Lab3.External.Interfaces;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.External.Entities;

public class FileDisplayDriver : IDisplayDriver
{
    public FileDisplayDriver(string filePath, Color color)
    {
        _filePath = filePath;
        Color = color;
        _text = string.Empty;
    }

    private readonly string _filePath;
    private string _text;

    public Color Color { get; set; }

    public void Clear()
    {
        File.WriteAllText(_filePath, string.Empty);
    }

    public void Paint(string text)
    {
        _text = $"FileDisplayDriver set {Color.Name} color: " + text + "\n";
    }

    public void WriteText()
    {
        File.AppendAllText(_filePath, _text);
    }
}