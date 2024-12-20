using Domain.Contracts;
using Spectre.Console;

namespace Presentation.User;

public class ReplenishAccountScenario : IScenario
{
    private readonly IUserService _userService;

    public ReplenishAccountScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Replenish account";

    public void Run()
    {
        try
        {
            int amount = AnsiConsole.Ask<int>("Enter the amount to top up your account:");
            _userService.Replenish(amount);
            AnsiConsole.MarkupLine("[green]The account has been successfully replenished![/]");
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red1]Error: {ex.Message}[/]");
        }
    }
}