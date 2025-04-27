using Domain.Contracts;
using Spectre.Console;

namespace Presentation.User;

public class UserLoginScenario : IScenario
{
    private readonly IUserService _userService;

    public UserLoginScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "User login";

    public void Run()
    {
        int accountNumber = AnsiConsole.Ask<int>("[yellow1]Enter account number:[/]");
        int pin = AnsiConsole.Prompt(
            new TextPrompt<int>("[orange3]Enter PIN:[/]")
                .PromptStyle("yellow1")
                .Secret());

        if (_userService.Login(accountNumber, pin))
        {
            AnsiConsole.MarkupLine("[green]You have successfully entered![/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red1]Login error: incorrect account number or PIN.[/]");
        }
    }
}