namespace Domain.Models;

public class Account
{
    public Account(int accountNumber, int pin, int balance)
    {
        AccountNumber = accountNumber;
        Pin = pin;
        Balance = balance;
    }

    public Account(int accountNumber, int pin)
    {
        AccountNumber = accountNumber;
        Pin = pin;
        Balance = 0;
    }

    public int AccountNumber { get; }

    public int Pin { get; }

    public int Balance { get; set; }
}