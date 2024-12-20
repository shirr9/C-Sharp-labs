using Domain.Contracts;
using Spectre.Console;

namespace Presentation.User;

public class WithdrawMoneyScenario : IScenario
{
    private readonly IUserService _userService;

    public WithdrawMoneyScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Withdraw money";

    public void Run()
    {
        try
        {
            int amount = AnsiConsole.Ask<int>("Enter the amount to withdraw:");
            _userService.Withdraw(amount);
            AnsiConsole.MarkupLine("[green]Money withdrawn successfully![/]");
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red1]Error: {ex.Message}[/]");
        }
    }
}