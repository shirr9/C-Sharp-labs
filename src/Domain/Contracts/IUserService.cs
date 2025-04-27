using Domain.Models;

namespace Domain.Contracts;

public interface IUserService
{
    bool Login(int accountNumber, int pin);

    void Logout();

    int GetBalance();

    void Replenish(int amount);

    void Withdraw(int amount);

    IEnumerable<Transaction> GetTransactionHistory();

    bool IsLoggedIn();
}