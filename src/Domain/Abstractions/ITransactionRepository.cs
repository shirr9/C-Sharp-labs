using Domain.Models;

namespace Domain.Abstractions;

public interface ITransactionRepository
{
    void AddTransaction(Transaction transaction, int accountNumber);

    IEnumerable<Transaction> GetTransactions(int accountNumber);
}
