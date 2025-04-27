using Itmo.ObjectOrientedProgramming.Lab3.External.Interfaces;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.External.Entities;

public class ConsoleDisplayDriver : IDisplayDriver
{
    public ConsoleDisplayDriver(Color color)
    {
        Color = color;
        _text = string.Empty;
    }

    public Color Color { get; set; }

    private string _text;

    public void Clear()
    {
        Console.Clear();
        Console.WriteLine("Clear");
    }

    public void Paint(string text)
    {
        _text = Crayon.Output.Rgb(Color.R, Color.G, Color.B).Text(text);
    }

    public void WriteText()
    {
        Console.WriteLine(_text);
    }
}