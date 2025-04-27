using Domain.Models;

namespace Domain.Contracts;

public interface IAccountService
{
    void Withdraw(int accountNumber, int pin, int amount);

    void Replenish(int accountNumber, int pin, int amount);

    int GetBalance(int accountNumber, int pin);

    public void Authenticate(int accountNumber, int pin);

    IEnumerable<Transaction> GetTransactionHistory(int accountNumber, int pin);
}