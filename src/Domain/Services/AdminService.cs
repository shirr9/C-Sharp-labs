using Domain.Abstractions;
using Domain.Contracts;
using Domain.Models;

namespace Domain.Services;

public class AdminService : IAdminService
{
    private readonly string _systemPassword;

    private readonly IAccountRepository _accountRepository;

    public AdminService(string systemPassword, IAccountRepository accountRepository)
    {
        _systemPassword = systemPassword;
        _accountRepository = accountRepository;
    }

    public bool IsLoggedIn { get; private set; }

    public bool Login(string password)
    {
        if (_systemPassword != password)
        {
            return false;
        }

        IsLoggedIn = true;
        return true;
    }

    public void CreateAccount(int accountNumber, int pin)
    {
        _accountRepository.CreateAccount(new Account(accountNumber, pin));
    }
}