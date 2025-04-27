using Domain.Contracts;
using Spectre.Console;

namespace Presentation.Admin;

public class AdminLoginScenario : IScenario
{
    private readonly IAdminService _adminService;

    public AdminLoginScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Admin login";

    public void Run()
    {
        string password = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter system password:")
                .PromptStyle("yellow1")
                .Secret());

        if (_adminService.Login(password))
        {
            AnsiConsole.MarkupLine("[green]Success![/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red1]Login error: incorrect system password.[/]");
        }
    }
}