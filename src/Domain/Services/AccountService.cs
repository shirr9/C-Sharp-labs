using Domain.Abstractions;
using Domain.Contracts;
using Domain.Exceptions;
using Domain.Models;

namespace Domain.Services;

public class AccountService : IAccountService
{
    public AccountService(IAccountRepository accountRepository, ITransactionRepository transactionRepository)
    {
        _accountRepository = accountRepository;
        _transactionRepository = transactionRepository;
    }

    private readonly IAccountRepository _accountRepository;

    private readonly ITransactionRepository _transactionRepository;

    public void Withdraw(int accountNumber, int pin, int amount)
    {
        Authenticate(accountNumber, pin);
        Account account = _accountRepository.GetAccount(accountNumber);
        int balance = account.Balance;

        if (balance < amount)
        {
            throw new InsufficientFundsException("Insufficient funds");
        }

        account.Balance -= amount;

        var transaction = new Transaction(DateTime.UtcNow, "Withdraw", amount, account.Balance);
        _transactionRepository.AddTransaction(transaction, accountNumber);

        _accountRepository.UpdateAccount(account);
    }

    public void Replenish(int accountNumber, int pin, int amount)
    {
        Authenticate(accountNumber, pin);
        Account account = _accountRepository.GetAccount(accountNumber);
        account.Balance += amount;

        var transaction = new Transaction(DateTime.UtcNow, "Replenish", amount, account.Balance);
        _transactionRepository.AddTransaction(transaction, accountNumber);

        _accountRepository.UpdateAccount(account);
    }

    public int GetBalance(int accountNumber, int pin)
    {
        Authenticate(accountNumber, pin);
        Account account = _accountRepository.GetAccount(accountNumber);
        return account.Balance;
    }

    public IEnumerable<Transaction> GetTransactionHistory(int accountNumber, int pin)
    {
        Authenticate(accountNumber, pin);
        return _transactionRepository.GetTransactions(accountNumber);
    }

    public void Authenticate(int accountNumber, int pin)
    {
        if (!_accountRepository.VerifyPin(accountNumber, pin))
        {
            throw new LoginErrorException("Incorrect account number or pin code");
        }
    }
}
