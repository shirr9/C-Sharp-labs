using Itmo.ObjectOrientedProgramming.Lab3.External.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.External.Entities;

public class Display : IDisplay
{
    private readonly IDisplayDriver _driver;

    public Display(IDisplayDriver driver)
    {
        _driver = driver;
    }

    public void ShowMessage(string message)
    {
        _driver.Clear();
        _driver.Paint(message);
        _driver.WriteText();
    }
}