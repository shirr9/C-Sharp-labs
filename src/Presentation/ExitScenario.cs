using Spectre.Console;

namespace Presentation;

public class ExitScenario : IScenario
{
    public string Name => "Exit";

    public void Run()
    {
        AnsiConsole.MarkupLine("[lightsteelblue]Goodbye![/]");
        Environment.Exit(0);
    }
}