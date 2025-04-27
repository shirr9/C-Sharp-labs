namespace Domain.Exceptions;

public class LoginErrorException(string message) : Exception(message);