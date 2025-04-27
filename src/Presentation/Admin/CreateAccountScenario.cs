using Domain.Contracts;
using Spectre.Console;

namespace Presentation.Admin;

public class CreateAccountScenario : IScenario
{
    private readonly IAdminService _adminService;

    public CreateAccountScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Create account";

    public void Run()
    {
        int accountNumber = AnsiConsole.Ask<int>("[orange1]Enter account number for a new account:[/]");

        int pin1 = AnsiConsole.Prompt(
            new TextPrompt<int>("Enter PIN for a new account:")
                .PromptStyle("orange1")
                .Secret());

        int pin2 = AnsiConsole.Prompt(
            new TextPrompt<int>("Enter PIN again:")
                .PromptStyle("orange1")
                .Secret());

        if (pin1 == pin2)
        {
            _adminService.CreateAccount(accountNumber, pin1);
            AnsiConsole.MarkupLine("[green]Create account successfully![/]");
        }
    }
}