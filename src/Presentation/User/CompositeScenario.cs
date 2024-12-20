using Spectre.Console;

namespace Presentation.User;

public class CompositeScenario : IScenario
{
    public IEnumerable<IScenario> Scenarios { get; }

    public CompositeScenario(IEnumerable<IScenario> scenarios)
    {
        Scenarios = scenarios;
    }

    public string Name => "Select action";

    public void Run()
    {
        IScenario scenario = AnsiConsole.Prompt(
            new SelectionPrompt<IScenario>()
                .Title("[lightskyblue1]Select action[/]")
                .HighlightStyle(new Style(foreground: new Color(135, 175, 0), decoration: Decoration.Bold))
                .AddChoices(Scenarios)
                .UseConverter(s => s.Name));

        scenario.Run();
    }
}