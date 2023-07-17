namespace CleanArchDotNet.Domain.Errors;

public class EntityError : BaseError
{
    public EntityError(string message) : base($"Field {message} is not valid")
    {}
}