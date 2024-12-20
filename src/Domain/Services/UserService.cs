using Domain.Contracts;
using Domain.Exceptions;
using Domain.Models;

namespace Domain.Services;

public class UserService : IUserService
{
    private readonly IAccountService _accountService;

    public int? LoggedInAccountNumber { get; private set; }

    private int? LoggedInPin { get; set; }

    public UserService(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public bool Login(int accountNumber, int pin)
    {
        try
        {
            _accountService.Authenticate(accountNumber, pin);
        }
        catch (LoginErrorException ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }

        LoggedInAccountNumber = accountNumber;
        LoggedInPin = pin;
        return true;
    }

    public void Logout()
    {
        LoggedInAccountNumber = null;
        LoggedInPin = null;
    }

    public int GetBalance()
    {
        if (LoggedInAccountNumber == null || LoggedInPin == null)
        {
            throw new InvalidOperationException("User not logged in");
        }

        return _accountService.GetBalance(LoggedInAccountNumber.Value, LoggedInPin.Value);
    }

    public void Replenish(int amount)
    {
        if (LoggedInAccountNumber == null || LoggedInPin == null)
        {
            throw new InvalidOperationException("User not logged in");
        }

        _accountService.Replenish(LoggedInAccountNumber.Value, LoggedInPin.Value, amount);
    }

    public void Withdraw(int amount)
    {
        if (LoggedInAccountNumber == null || LoggedInPin == null)
        {
            throw new InvalidOperationException("User not logged in");
        }

        _accountService.Withdraw(LoggedInAccountNumber.Value, LoggedInPin.Value, amount);
    }

    public IEnumerable<Transaction> GetTransactionHistory()
    {
        if (LoggedInAccountNumber == null || LoggedInPin == null)
        {
            throw new InvalidOperationException("User not logged in");
        }

        return _accountService.GetTransactionHistory(LoggedInAccountNumber.Value, LoggedInPin.Value);
    }

    public bool IsLoggedIn()
    {
        return LoggedInAccountNumber != null && LoggedInPin != null;
    }
}
