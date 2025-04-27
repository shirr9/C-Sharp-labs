namespace Domain.Exceptions;

public class InsufficientFundsException(string message) : Exception(message);