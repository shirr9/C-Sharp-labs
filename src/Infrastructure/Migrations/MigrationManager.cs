using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Migrations;

public class MigrationManager
{
    private readonly string _connectionString;

    public MigrationManager(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void ApplyMigrations()
    {
        IServiceProvider serviceProvider = CreateServices();
        using IServiceScope scope = serviceProvider.CreateScope();
        IMigrationRunner runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
        runner.MigrateUp();
    }

    private ServiceProvider CreateServices()
    {
        return new ServiceCollection()
            .AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                .AddPostgres()
                .WithGlobalConnectionString(_connectionString)
                .ScanIn(typeof(MigrationManager).Assembly).For.Migrations())
            .AddLogging(lb => lb.AddFluentMigratorConsole())
            .BuildServiceProvider(false);
    }
}