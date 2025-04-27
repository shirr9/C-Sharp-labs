using Presentation.User;
using Spectre.Console;

namespace Presentation;

public class ScenarioRunner
{
    private readonly IEnumerable<IScenarioProvider> _providers;

    public ScenarioRunner(IEnumerable<IScenarioProvider> providers)
    {
        _providers = providers;
    }

    public void Run()
    {
        IEnumerable<IScenario> scenarios = FlattenScenarios(GetScenarios());

        SelectionPrompt<IScenario> selector = new SelectionPrompt<IScenario>()
            .Title("[lightskyblue1]Select action[/]")
            .HighlightStyle(new Style(foreground: new Color(135, 175, 0), decoration: Decoration.Bold))
            .AddChoices(scenarios)
            .UseConverter(x => x.Name);

        IScenario scenario = AnsiConsole.Prompt(selector);
        scenario.Run();
    }

    private IEnumerable<IScenario> GetScenarios()
    {
        foreach (IScenarioProvider provider in _providers)
        {
            if (provider.TryGetScenario(out IScenario? scenario))
                yield return scenario;
        }

        yield return new ExitScenario();
    }

    private IEnumerable<IScenario> FlattenScenarios(IEnumerable<IScenario> scenarios)
    {
        foreach (IScenario scenario in scenarios)
        {
            if (scenario is CompositeScenario compositeScenario)
            {
                foreach (IScenario nestedScenario in compositeScenario.Scenarios)
                {
                    yield return nestedScenario;
                }
            }
            else
            {
                yield return scenario;
            }
        }
    }
}