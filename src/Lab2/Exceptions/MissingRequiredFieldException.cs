namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class MissingRequiredFieldException : Exception
{
    public MissingRequiredFieldException(string fieldName)
        : base($"The required field '{fieldName}' is missing.")
    {
    }
}