using Domain.Contracts;
using Domain.Models;
using Spectre.Console;

namespace Presentation.User;

public class ViewTransactionHistoryScenario : IScenario
{
    private readonly IUserService _userService;

    public ViewTransactionHistoryScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "View transaction history";

    public void Run()
    {
        IEnumerable<Transaction> transactions = _userService.GetTransactionHistory();

        Table table = new Table()
            .AddColumn("Date")
            .AddColumn("Type")
            .AddColumn("Amount")
            .AddColumn("Balance");

        table.Title = new TableTitle("[bold skyblue1]Operation history[/]");

        foreach (Transaction transaction in transactions)
        {
            table.AddRow(
                transaction.Timestamp.ToString(),
                $"[indianred1_1]{transaction.Type}[/]",
                transaction.Amount.ToString(),
                transaction.NewBalance.ToString());
        }

        AnsiConsole.Write(table);
    }
}