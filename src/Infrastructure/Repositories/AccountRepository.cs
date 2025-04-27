using Domain.Abstractions;
using Domain.Models;
using Npgsql;

namespace Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly string _connectionString;

    public AccountRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public bool VerifyPin(int accountNumber, int pin)
    {
        const string sql = """
                           SELECT COUNT(1)
                           FROM "Accounts"
                           WHERE "AccountNumber" = @AccountNumber AND "Pin" = @Pin;
                           """;
        try
        {
            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();

            using var command = new NpgsqlCommand(sql, connection);
            command.Parameters.AddWithValue("@AccountNumber", accountNumber);
            command.Parameters.AddWithValue("@Pin", pin);

            int result = Convert.ToInt32(command.ExecuteScalar());
            return result > 0;
        }
        catch (NpgsqlException ex)
        {
            Console.WriteLine($"Database connection error when checking PIN: {ex.Message}");
            throw new ApplicationException("Error connecting to the database. Please try again later.", ex);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"General error when checking PIN: {ex.Message}");
            throw new ApplicationException("Failed to verify the PIN. Please try again later.", ex);
        }
    }

    public Account GetAccount(int accountNumber)
    {
        const string sql = """
                           SELECT "AccountNumber", "Pin", "Balance"
                           FROM "Accounts"
                           WHERE "AccountNumber" = @AccountNumber;
                           """;
        try
        {
            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();

            using var command = new NpgsqlCommand(sql, connection);
            command.Parameters.AddWithValue("@AccountNumber", accountNumber);

            using NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Account(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2));
            }

            throw new ApplicationException("Account not found.");
        }
        catch (NpgsqlException ex)
        {
            Console.WriteLine($"Database connection error when retrieving account: {ex.Message}");
            throw new ApplicationException("Error retrieving account data. Please try again later.", ex);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"General error when retrieving account: {ex.Message}");
            throw new ApplicationException("Failed to retrieve account. Please try again later.", ex);
        }
    }

    public void CreateAccount(Account account)
    {
        const string sql = """
                           INSERT INTO "Accounts" ("AccountNumber", "Pin", "Balance")
                           VALUES (@AccountNumber, @Pin, @Balance);
                           """;

        try
        {
            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();

            using var command = new NpgsqlCommand(sql, connection);
            command.Parameters.AddWithValue("@AccountNumber", account.AccountNumber);
            command.Parameters.AddWithValue("@Pin", account.Pin);
            command.Parameters.AddWithValue("@Balance", account.Balance);

            command.ExecuteNonQuery();
        }
        catch (NpgsqlException ex)
        {
            Console.WriteLine($"Database error when creating account: {ex.Message}");
            throw new ApplicationException("Error creating the account.", ex);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"General error when creating account: {ex.Message}");
            throw new ApplicationException("Failed to create account. Please try again later.", ex);
        }
    }

    public void UpdateAccount(Account account)
    {
        const string sql = """
                           UPDATE "Accounts" 
                           SET "Pin" = @Pin, "Balance" = @Balance
                           WHERE "AccountNumber" = @AccountNumber;
                           """;

        try
        {
            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();

            using var command = new NpgsqlCommand(sql, connection);
            command.Parameters.AddWithValue("@AccountNumber", account.AccountNumber);
            command.Parameters.AddWithValue("@Pin", account.Pin);
            command.Parameters.AddWithValue("@Balance", account.Balance);

            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected == 0)
            {
                throw new ApplicationException("No account was updated. Account may not exist.");
            }
        }
        catch (NpgsqlException ex)
        {
            Console.WriteLine($"Database error when updating account: {ex.Message}");
            throw new ApplicationException("Error updating the account.", ex);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"General error when updating account: {ex.Message}");
            throw new ApplicationException("Failed to update account. Please try again later.", ex);
        }
    }
}