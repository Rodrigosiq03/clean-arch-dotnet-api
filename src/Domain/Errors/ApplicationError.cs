namespace Domain.Errors;

public class ApplicationError : BaseError
{
    public ApplicationError(string message) : base($"Not found for {message}")
    {}

    public ApplicationError() : base("Access forbidden")
    {}
}