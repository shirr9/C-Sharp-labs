namespace Domain.Models;

public class Transaction
{
    public Transaction(DateTime timestamp, string type, int amount, int newBalance)
    {
        Timestamp = timestamp;
        Type = type;
        Amount = amount;
        NewBalance = newBalance;
    }

    public DateTime Timestamp { get; }

    public string Type { get; }

    public int Amount { get; }

    public int NewBalance { get; }
}