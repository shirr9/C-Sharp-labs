using Domain.Models;

namespace Domain.Abstractions;

public interface IAccountRepository
{
    bool VerifyPin(int accountNumber, int pin);

    Account GetAccount(int accountNumber);

    void CreateAccount(Account account);

    void UpdateAccount(Account account);
}