using FluentMigrator;

namespace Infrastructure.Migrations;

[Migration(1)]
public class CreateTables : Migration
{
    public override void Up()
    {
        Create.Table("Accounts")
            .WithColumn("AccountNumber").AsInt32().PrimaryKey()
            .WithColumn("Pin").AsInt32().NotNullable()
            .WithColumn("Balance").AsInt32().NotNullable().WithDefaultValue(0);

        Create.Table("Transactions")
            .WithColumn("TransactionId").AsInt64().PrimaryKey().Identity()
            .WithColumn("AccountNumber").AsInt32().NotNullable()
            .ForeignKey("Accounts", "AccountNumber")
            .WithColumn("Date").AsDateTime().NotNullable().WithDefaultValue(SystemMethods.CurrentDateTime)
            .WithColumn("TransactionType").AsString(50).NotNullable()
            .WithColumn("Amount").AsInt32().NotNullable().WithDefaultValue(0)
            .WithColumn("NewBalance").AsInt32().NotNullable();
    }

    public override void Down()
    {
        Delete.Table("transactions");
        Delete.Table("accounts");
    }
}