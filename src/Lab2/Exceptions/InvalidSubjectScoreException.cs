namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class InvalidSubjectScoreException : Exception
{
    public InvalidSubjectScoreException(string message) : base(message)
    {
    }
}