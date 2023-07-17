namespace CleanArchDotNet.Domain.Errors;

public class BaseError : Exception
{
    private string _message;
    
    public BaseError(string message) : base(message)
    {
        _message = message;
    }

    public override string Message => _message;

}
