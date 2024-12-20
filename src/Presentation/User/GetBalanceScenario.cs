using Domain.Contracts;
using Spectre.Console;

namespace Presentation.User;

public class GetBalanceScenario : IScenario
{
    private readonly IUserService _userService;

    public GetBalanceScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Get balance";

    public void Run()
    {
        try
        {
            int balance = _userService.GetBalance();
            AnsiConsole.MarkupLine($"Your current balance: [green]{balance}.[/]");
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red1]Error: {ex.Message}[/]");
        }
    }
}