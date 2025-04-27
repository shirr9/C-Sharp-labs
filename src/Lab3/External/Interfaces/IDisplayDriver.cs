using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.External.Interfaces;

public interface IDisplayDriver
{
    void Clear();

    Color Color { get; set; }

    void Paint(string text);

    void WriteText();
}