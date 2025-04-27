namespace Domain.Contracts;

public interface IAdminService
{
    bool IsLoggedIn { get; }

    bool Login(string password);

    public void CreateAccount(int accountNumber, int pin);
}