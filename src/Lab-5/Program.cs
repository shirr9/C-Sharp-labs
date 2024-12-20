// See https://aka.ms/new-console-template for more information

using Domain.Abstractions;
using Domain.Contracts;
using Domain.Services;
using Infrastructure.Migrations;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Presentation;
using Presentation.Admin;
using Presentation.User;
using Spectre.Console;

var services = new ServiceCollection();

const string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=my_new_database";

const string systemPassword = "admin";

services.AddSingleton(systemPassword);
services.AddScoped<IAccountRepository, AccountRepository>(_ => new AccountRepository(connectionString));
services.AddScoped<ITransactionRepository, TransactionRepository>(_ => new TransactionRepository(connectionString));
services.AddScoped<IAdminService, AdminService>();
services.AddScoped<IAccountService, AccountService>();
services.AddScoped<IUserService, UserService>();
services.AddScoped<MigrationManager>(_ => new MigrationManager(connectionString));

services.AddScoped<IScenarioProvider, AdminLoginScenarioProvider>();
services.AddScoped<IScenarioProvider, CreateAccountScenarioProvider>();
services.AddScoped<IScenarioProvider, UserLoginScenarioProvider>();
services.AddScoped<IScenarioProvider, UserOperationsScenarioProvider>();

services.AddScoped<ScenarioRunner>();

ServiceProvider serviceProvider = services.BuildServiceProvider();

// добавление миграций
try
{
    MigrationManager migrationManager = serviceProvider.GetRequiredService<MigrationManager>();
    migrationManager.ApplyMigrations();
    AnsiConsole.MarkupLine("[green]Migrations applied successfully![/]");
}
catch (Exception ex)
{
    AnsiConsole.MarkupLine($"[red1]Error applying migrations: {ex.Message}[/]");
    return;
}

// основной цикл программы
ScenarioRunner scenarioRunner = serviceProvider.GetRequiredService<ScenarioRunner>();

while (true)
{
    scenarioRunner.Run();
    AnsiConsole.MarkupLine("Press [darkgoldenrod]Enter[/] to continue...");
    Console.ReadLine();
    AnsiConsole.Clear();
}