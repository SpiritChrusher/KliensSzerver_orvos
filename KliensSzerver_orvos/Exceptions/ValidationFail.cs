namespace KliensSzerver_orvos.Exceptions;

public class ValidationFail : Exception
{
    public ValidationFail()
    {
    }

    public ValidationFail(string message) : base(message)
    {
    }
}
