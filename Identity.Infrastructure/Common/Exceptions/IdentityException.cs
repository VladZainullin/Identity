namespace Identity.Infrastructure.Common.Exceptions;

internal sealed class IdentityException : Exception
{
    public IdentityException(string message) : base(message)
    {
    }
}