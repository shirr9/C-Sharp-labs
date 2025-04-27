using Domain.Abstractions;
using Domain.Models;
using Npgsql;

namespace Infrastructure.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly string _connectionString;

    public TransactionRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void AddTransaction(Transaction transaction, int accountNumber)
    {
        const string sql = """
                     INSERT INTO "Transactions" ("AccountNumber", "TransactionType", "Amount", "NewBalance")
                     VALUES (@AccountNumber, @TransactionType, @Amount, @NewBalance);
                     """;
        try
        {
            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();

            using var command = new NpgsqlCommand(sql, connection);
            command.Parameters.AddWithValue("@AccountNumber", accountNumber);
            command.Parameters.AddWithValue("@TransactionType", transaction.Type);
            command.Parameters.AddWithValue("@Amount", transaction.Amount);
            command.Parameters.AddWithValue("@NewBalance", transaction.NewBalance);

            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected == 0)
            {
                throw new ApplicationException("Transaction was not inserted. Check the data.");
            }
        }
        catch (NpgsqlException ex)
        {
            Console.WriteLine($"Database error when adding transaction: {ex.Message}");
            throw new ApplicationException("Error adding transaction.", ex);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"General error when adding transaction: {ex.Message}");
            throw new ApplicationException("Failed to add transaction. Please try again later.", ex);
        }
    }

    public IEnumerable<Transaction> GetTransactions(int accountNumber)
    {
        var transactions = new List<Transaction>();

        const string sql = """
                           SELECT "Date", "TransactionType", "Amount", "NewBalance"
                           FROM "Transactions"
                           WHERE "AccountNumber" = @AccountNumber
                           ORDER BY "Date" DESC;
                           """;
        try
        {
            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();

            using var command = new NpgsqlCommand(sql, connection);
            command.Parameters.AddWithValue("@AccountNumber", accountNumber);
            using NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                var transaction = new Transaction(
                    reader.GetDateTime(0),
                    reader.GetString(1),
                    reader.GetInt32(2),
                    reader.GetInt32(3));

                transactions.Add(transaction);
            }

            return transactions;
        }
        catch (NpgsqlException ex)
        {
            Console.WriteLine($"Database error when retrieving transactions: {ex.Message}");
            throw new ApplicationException("Error retrieving transactions.", ex);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"General error when retrieving transactions: {ex.Message}");
            throw new ApplicationException("Failed to retrieve transactions. Please try again later.", ex);
        }
    }
}